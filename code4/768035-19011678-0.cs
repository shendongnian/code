    public class Tests
    {
        [Fact]
        public void TryingToAccessBootedKernelBeforeBootThrowsException()
        {
            var appDomain = AppDomain.Create(Guid.NewGuid());
            try
            {
                appDomain.DoCallBack(new CrossAppDomainDelegate(TryingToAccessBootedKernelBeforeBootThrowsException_AppDomainCallback));
            }
            catch (Exception e)
            {
                Assert.IsType(typeof(InvalidOperationException), e.InnerException);
            }
    
            AppDomain.Unload(appDomain);
        }
        public static void TryingToAccessBootedKernelBeforeBootThrowsException_AppDomainCallback()
        {
            var bootstrapper = BootStrapper.Booted;
        }
    }
