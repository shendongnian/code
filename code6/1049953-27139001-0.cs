        public class FakeItEasyStrictRelay : ISpecimenBuilder
        {
            public object Create(object request, ISpecimenContext context)
            {
                if (context == null)
                    throw new ArgumentNullException("context");
    
                if (!this.IsSatisfiedBy(request))
                    return new NoSpecimen(request);
    
                var type = request as Type;
                if (type == null)
                    return new NoSpecimen(request);
    
                var fakeFactoryMethod = this.GetType()
                    .GetMethod("CreateStrictFake", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod((Type) request);
    
                var fake = fakeFactoryMethod.Invoke(this, new object[0]);
    
                return fake;
            }
    
            public bool IsSatisfiedBy(object request)
            {
                var t = request as Type;
                return (t != null) && ((t.IsAbstract) || (t.IsInterface));
            }
    
            private T CreateStrictFake<T>()
            {
                return A.Fake<T>(s => s.Strict());
            }
        }
