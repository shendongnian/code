    public class SystemServiceTests
    {
        [Fact]
        public void GetSystemReturnsFromContext()
        {
            var context = new TestContext();
            context.Systems.Add(new Models.System { Id = 1, Name = "System 1" });
            context.Systems.Add(new Models.System { Id = 2, Name = "System 2" });
            context.Systems.Add(new Models.System { Id = 3, Name = "System 3" });
            var service = new SystemService(context);
            var system = service.GetSystem(2);
            Assert.NotNull(system);
            Assert.Equal(2, system.Id);
            Assert.Equal("System 2", system.Name);
        }
    }
