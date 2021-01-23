    TextBox Box = new TextBox()
    Button Butt = new Button();
    Box = (TextBox)e.Item.FindControl("TextBoxComment")
    Butt = (Button)e.Item.FindControl("ButtonSubmit")
    Box.Visible = false;
