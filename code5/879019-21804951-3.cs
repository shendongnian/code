    ...
    MyClass c = new MyClass();
    button1.Tag = c;
    ....
    private void button_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        MyClass t = btn.Tag as MyClass
        if(t != null) 
           ......
    }
