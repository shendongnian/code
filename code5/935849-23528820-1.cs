    public class ModelFactory
    {
        public FooModel Create(Foo foo)
        {
            var fooModel = new FooModel()
            { ... };
            
            // pass this model instance to the Create method
            fooModel.Bars = foo.Bars
                  .Select(b => Create(b, fooModel))
                  .ToList();
            return fooModel;
        }
        // how about making this private?
        // can a Bar exist without a Foo parent?
        private BarModel Create(Bar bar, FooModel parentModel)
        {
            return new BarModel()
            {
                // we don't create a new model here
                Foo = parentModel
            };
        }
    }
