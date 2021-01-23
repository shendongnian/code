    public class MyPropertyStore
    {
        public AbstractClass MyProperty {get;set;}
    }
    public class Test2
    {      
        private MyPropertyStore propertyStore;
        public AbstractClass Y { get { return propertyStore.MyProperty ;} }
        public Test2(MyPropertyStore propertyStore)
        {
            this.propertyStore= propertyStore;
        }
    }
    public void Main()
    {
        AbstractClass X = new Foo();
        MyPropertyStore store = new MyPropertyStore 
        {
         MyProperty  = X,
        };
        Test2 test2 = new Test2(store);
        store.MyProperty = new Bar(); // Now test2.Y will be pointing to same reference
        //Now, X is Bar, and Y is Foo. 
        if (X == test2.Y)
            MessageBox.Show("They are equal! Success!!");
        else
            MessageBox.Show("Not equal :( ");
    }
