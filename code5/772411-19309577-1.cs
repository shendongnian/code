        public override IEnumerable<object[]> GetData(System.Reflection.MethodInfo methodUnderTest, Type[] parameterTypes)
        {
            foreach (var values in base.GetData(methodUnderTest, parameterTypes))
            {
                // The params returned by the base class are the first m params, 
                // and the rest of the params can be satisfied by AutoFixture using
                // its InlineAutoDataAttribute class.
                var cda = new CompositeDataAttribute(new DataAttribute[] {
                                   new InlineAutoDataAttribute(values)
                               } );
                foreach (var parameters in cda.GetData(methodUnderTest, parameterTypes))
                    yield return parameters;
            }
        }
