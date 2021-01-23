    class MyArgs : EventArgs
    {
        public string What { get; set; }
    }
    delegate void MyHandler(object sender, MyArgs e);
    . . .
    var myEvent = birthEvent;
    if (myEvent != null)
        myEvent(new MyArgs { What = "Birth"};
