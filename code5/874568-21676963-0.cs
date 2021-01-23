    public interface IUnitOfWork
    {
        IUnitOfWorkScope Start();
    }
    internal class UnitOfWork : IUnitOfWork
    {
        public static readonly ThreadLocal<IUnitOfWorkScope> LocalUnitOfWork = new ThreadLocal<IUnitOfWorkScope>();
        private readonly IResolutionRoot resolutionRoot;
        public UnitOfWork(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
        public IUnitOfWorkScope Start()
        {
            if (LocalUnitOfWork.Value == null)
            {
                LocalUnitOfWork.Value = this.resolutionRoot.Get<IUnitOfWorkScope>();
            }
            return LocalUnitOfWork.Value;
        }
    }
    public interface IUnitOfWorkScope : IDisposable
    {
        Guid Id { get; }
    }
    public class UnitOfWorkScope : IUnitOfWorkScope
    {
        public UnitOfWorkScope()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public void Dispose()
        {
            UnitOfWork.LocalUnitOfWork.Value = null;
        }
    }
    public class UnitOfWorkIntegrationTest : IDisposable
    {
        private readonly IKernel kernel;
        public UnitOfWorkIntegrationTest()
        {
            this.kernel = new StandardKernel();
            this.kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            this.kernel.Bind<IUnitOfWorkScope>().To<UnitOfWorkScope>();
        }
        [Fact]
        public void MustCreateNewScopeWhenOldOneWasDisposed()
        {
            Guid scopeId1;
            using (IUnitOfWorkScope scope = this.kernel.Get<IUnitOfWork>().Start())
            {
                scopeId1 = scope.Id;
            }
            Guid scopeId2;
            using (IUnitOfWorkScope scope = this.kernel.Get<IUnitOfWork>().Start())
            {
                scopeId2 = scope.Id;
            }
            scopeId1.Should().NotBe(scopeId2);
        }
        [Fact]
        public void NestedScope_MustReuseSameScope()
        {
            Guid scopeId1;
            Guid scopeId2;
            using (IUnitOfWorkScope scope1 = this.kernel.Get<IUnitOfWork>().Start())
            {
                scopeId1 = scope1.Id;
                using (IUnitOfWorkScope scope2 = this.kernel.Get<IUnitOfWork>().Start())
                {
                    scopeId2 = scope2.Id;
                }
            }
            scopeId1.Should().Be(scopeId2);
        }
        [Fact]
        public void MultipleThreads_MustCreateNewScopePerThread()
        {
            var unitOfWork = this.kernel.Get<IUnitOfWork>();
            Guid scopeId1;
            Guid scopeId2 = Guid.Empty;
            using (IUnitOfWorkScope scope1 = unitOfWork.Start())
            {
                scopeId1 = scope1.Id;
                Task otherThread = Task.Factory.StartNew(() =>
                    {
                        using (IUnitOfWorkScope scope2 = unitOfWork.Start())
                        {
                            scopeId2 = scope2.Id;
                        }
                    },
                    TaskCreationOptions.LongRunning);
                if (!otherThread.Wait(TimeSpan.FromSeconds(5)))
                {
                    throw new TimeoutException();
                }
            }
            scopeId2.Should().NotBeEmpty();
            scopeId1.Should().NotBe(scopeId2);
        }
        public void Dispose()
        {
            this.kernel.Dispose();
        }
    }
