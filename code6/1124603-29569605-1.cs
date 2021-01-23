    class A : FrameworkElement
    {
        public int CountMyBs() {}
    }
    
    class B : FrameworkElement
    {
        public void Foo()
        {
            var parent = LogicalTreeHelper.GetParent(this) as A;
            if (parent != null)
            {
                //here i would like to use "CountMyBs()"
                parent.CountMyBs();
            }
        }
    }
