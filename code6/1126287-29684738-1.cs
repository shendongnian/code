    public class MyClass
    {
        // MyDelegate callback holder
        private MyDelegate _myDelegate;
    
    
        ///<summary>
        /// MyClass constructor
        ///</summary>
        public MyClass()
        {
            // Define the callback
            MyDelegate = MyDelegateCallback;
        }
    
        ///<summary>
        /// MyDelegate property, here u can change the callback to any function which matches the structure of MyDelegate 
        ///</summary>
        public MyDelegate MyDelegate
        {
            get
            {
                return _myDelegate;
            }
            set
            {
                _myDelegate = value;
            }
        }
    
        ///<summary>
        /// Call all given callbacks
        ///</summary>
        ///<param name="callbacks">callbacks u want to call</param>
        public void MyCallbacks(params MyDelegate[] callbacks)
        {
            if (callbacks != null)
            {
                foreach (MyDelegate callback in callbacks)
                {
                    if (callback != null)
                    {
                        callback.Invoke(null);
                    }
                }
            }
        }
    
        ///<summary>
        /// RunTest, if u call this method the defined callback will be raised
        ///</summary>
        public void RunTest()
        {
            if (_myDelegate != null)
            {
                _myDelegate.Invoke("test");
            }
        }
    
        ///<summary>
        /// MyDelegateCallback, the callback we want to raise
        ///</summary>
        ///<param name="obj"></param>
        private void MyDelegateCallback(object obj)
        {
            System.Windows.MessageBox.Show("Delegate callback called!");
        }
    
    }
    
    ///<summary>
    /// MyDelegate, the delegate function
    ///</summary>
    ///<param name="obj"></param>
    public delegate void MyDelegate(object obj);
