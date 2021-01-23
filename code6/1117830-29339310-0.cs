    class MyClass
    {
        public MyClass() { cake.PropertyChanged += HandleCakeChanged; }
        void HandleCakeChanged(object sender, EventArgs args)
        {
            // do stuff
        }
    }
