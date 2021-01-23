    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           SetUpLabel();
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "Some more text";
        TextBox1.ForeColor = System.Drawing.Color.Blue;
    
        SetUpLabel();
    }
    
    private void SetUpLabel()
    {
        Label1.Text = "TextBox1.Text = " + TextBox1.Text + "<br />";
        Label1.Text += "TextBox1.Forecolor = " TextBox1.ForeColor.ToString();
    }
