    //This is in the ViewModelLocator.cs
    
    // Define one key for each view/page. 
    // You can call them anything but I use my view/class name followed by "Key"
    
    public const string MvvmView1Key  = "MvvmView1"; 
    
    var nav = new NavigationService();
    
    nav.Configure(ViewModelLocator.MvvmView1Key, typeof(MvvmView1)); 
    
    // Assuming that your view class is called MvvmView1.
