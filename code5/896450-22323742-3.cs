        public class SomeSoftDeletableEntity : ISoftDeletable
        {
        }
        [Fact]
        public void RepositoryBinding()
        {
            var kernel = new StandardKernel();
            kernel.Load<RepositoryModule>();
            IRepository<SomeSoftDeletableEntity> repository = kernel.Get<IRepository<SomeSoftDeletableEntity>>();
            repository.Should().BeOfType<SoftDeletableRepository<SomeSoftDeletableEntity>>();
        }
