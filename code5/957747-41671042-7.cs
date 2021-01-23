    protected override void OnLoad(EventArgs e)
    {
        //kontrol yüklendiğinde çalışacak kodlar       
        base.OnLoad(e);       
    }
     protected override void OnInit(EventArgs e)
    {               
        base.OnInit(e);
        InitializeComponent();        
    }
      private void InitializeComponent()
    {
       btn1.Click += new EventHandler(btn1_Click);      
    
    }
     protected void btn1_Click(object sender, EventArgs e)// not working....
    {
        Txt1.Text = "Example";   // not working....    
    
    }
