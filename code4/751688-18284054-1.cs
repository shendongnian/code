    protected void Page_Load(object sender, EventArgs e)
    {
        Label Label1 = new Label();
        Label1.ID="Label1";
        Label1.Text = "Please enter info: ";
        this.Controls.Add(Label1);
        TextBox Textbox1 = new TextBox();
        Textbox1.ID="Textbox1";
        this.Controls.Add(Textbox1);
        Button Button1 = new Button();
        Button1.ID = "Button1";
        Button1.Text = "Submit";
        this.Controls.Add(Button1);
    }
