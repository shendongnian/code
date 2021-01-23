    private delegate void Update();
    public void addlist(string st)
     {
       listBox1.Invoke(new Update(() => listBox1.Items.Add(youritem)));  
     }
