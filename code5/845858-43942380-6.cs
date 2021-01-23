        public DesignTimeVM()  //I'm using this as a Design Time VM 
        {
            Items = new List<Foo>();
            Items.Add(new Foo() { FooProp= "1", FooPrep= 20.0 });
            Items.Add(new Foo() { FooProp= "2", FooPrep= 30.0 });
            FooViewSource = new CollectionViewSource();
            FooViewSource.Source = Items;
            SelectedFoo = Items.First();
            //More code as needed
        }
