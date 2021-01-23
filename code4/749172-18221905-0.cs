    [TestFixture]
    public class MyBasicObjectServiceFixture
    {
        [Test]
        public void GetByNameShouldCallCacheProviderFunction()
        {
            // Arrange
            MockRepository mock = new MockRepository();
            IMyBasicObjectRepository repo = mock.DynamicMock<IMyBasicObjectRepository>();
            ICacheProvider cacheProvider = mock.DynamicMock<ICacheProvider>();
            MyBasicObjectService service = new MyBasicObjectService(cacheProvider, repo);
            cacheProvider.Expect(p => p.Get<MyBasicObject>(Arg<string>.Is.Equal("AnUniqueName"), Arg<Func<MyBasicObject>>.Is.NotNull))
                    .WhenCalled(call => 
                        {
                            var repoCall = (Func<MyBasicObject>)call.Arguments[1];
                            repoCall.Invoke();
                        });
                repo.Expect(c => c.GetByName("AnUniqueName"));
            mock.ReplayAll();
            // Act
            var result = service.GetByName("AnUniqueName");
            // Assert
            mock.VerifyAll();
        }
    }
