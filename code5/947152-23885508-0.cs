    public partial class UserControlA
    {
        // method to inform
        public void DoSomething(string text)
        {
            ... // do something with text
        }
    }
    public partial class UserControlB
    {
        public event Action SomethingChanged;
        public string SomeText {get; set;} // some property
        
        private void button1Clicked(object sender, EventArgs e)
        {
            if(SomethingChanged != null)
                SomethingChanged(); 
        }
    }
    // in form contructor (for demonstration purpose)
    var a = new UserControlA();
    var b = new UserControlB();
    this.Controls.Add(a);
    this.Controls.Add(b);
    var handler = () => a.DoSomething(b.SomeText);
    b.SomethingChanged += handler;
