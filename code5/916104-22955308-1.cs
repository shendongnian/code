        [Test]
        public void doTest()
        {
            MatchedTypeInterceptor interceptor = new MatchedTypeInterceptor(
                 x => x.FindFirstInterfaceThatCloses(typeof (IRepository<>)) != null);
            interceptor.InterceptWith(original =>
            {
                Type closedType = original.GetType()
                     .FindFirstInterfaceThatCloses(typeof(IRepository<>));
                var genericParameters = closedType.GetGenericArguments();
                var closedCacheType = typeof(RepositoryCache<>)
                     .MakeGenericType(genericParameters);
                return Activator.CreateInstance(closedCacheType, new[] {original});
            });
            ObjectFactory.Initialize(x =>
            {
                x.For(typeof (IRepository<>)).Use(typeof (Repository<>));
                x.RegisterInterceptor(interceptor);
            });
            var test = ObjectFactory.GetInstance<IRepository<int>>();
            
            Assert.That(test is RepositoryCache<int>);
        }
