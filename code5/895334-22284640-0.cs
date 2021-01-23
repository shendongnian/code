    button1.Click += new System.EventHandler(MyButtonClick);
    button2.Click += new System.EventHandler(MyButtonClick);
    button3.Click += new System.EventHandler(MyButtonClick);
    private void MyButtonClick(object sender, EventArgs e)
    {
      Button btnClick =  (Button)sender ;
      guess(btnClick.Text);
    }
