     void Page_Load(Object sender, EventArgs e)
     { 
        TextBox input = new TextBox();
        input.Id ="input";
        this.PlaceHolder.Controls.Add(input);
    
        Button btnSend=new Button();
        btnSend.Id ="btnSend";
        btnSend.Text="Send";
        btnSend.Click += new EventHandler(btnSend_Click);
        this.PlaceHolder.Controls.Add(btnSend);
    }
    void btnSend_Click(object sender, EventArgs e)
    {
          // throw new NotImplementedException();
    }
    
 
