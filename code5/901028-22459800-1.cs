        public abstract class FooBar
        {
            public void Save()
            {
                var fooBarId = this.GenerateId("myproduct");
                SaveCore(fooBarId);
                //fooBarId will be used in this code block
            }
            protected abstact void SaveCore(int id);
        }
