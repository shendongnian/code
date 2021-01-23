    protected void Page_Load(object sender, EventArgs e)
    {
        Button button = new Button { ID = "btn1", Text = "Click Me" };
        button.Click += btn_Click;
        PlaceHolder btnPlaceHolder = new PlaceHolder();
        btnPlaceHolder.Controls.Add(button);
    }
    private void btn_Click(object sender, EventArgs e)
    {
        Response.Write("Testing");
    }
