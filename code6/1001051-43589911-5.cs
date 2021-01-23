    public partial class MyViewController : UIViewController
    {
        #if DEBUG
        static int _counter;
    	#endif
    
        protected MyViewController  (IntPtr handle) : base (handle)
        {
    		#if DEBUG
            Interlocked.Increment (ref _counter);
            Debug.WriteLine ("MyViewController Instances {0}.", _counter);
    		#endif
         }
	    #if DEBUG
    	~MyViewController()
    	{
            Debug.WriteLine ("ViewController deleted, {0} instances left.", 
                             Interlocked.Decrement(ref _counter));
    	}
    	#endif
    }
