    public Main()
    {
        Sub.GotPicked += OnGotPicked
    }
    void sub_myClick(object sender, EventArgs e)
    {   
        Sub.executeMethodDelegate();   //I have object Sub available with all its functions
    }
    public void OnGotPicked(object sender, SubEventArgs e)
    {
        // Do something with myObject
        var myObject = e.MyObject;
    }
    public class SubEventArgs : EventArgs
    {
        public SubEventArgs(MyObject obj)
        {
              MyObject = obj;
        }
        public readonly MyObject MyObject { get; set; }
    }
