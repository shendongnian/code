     protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            GenerateButton_Click(sender, e);
    }
   
  
    public TextBox[] s;
   
    protected void GenerateButton_Click(object sender, EventArgs e)
    {
       
      int z = Convert.ToInt32(HowManyToGenerateTextBox.Text);
      Panel1.Controls.Clear();
      Array.Resize(ref s, z);
      for (int i = 0; i < z; i++)
      {
          s[i] = new TextBox();
          s[i].ID = "tb" + i.ToString();
          s[i].Text = "tb" + i.ToString();
          Session[s[i].ID] = s;
          Panel1.Controls.Add(s[i]);
      }
    }
    protected void CalculateButton_Click(object sender, EventArgs e)
    {
       ResultLabel.Text = s[0].Text;      
    }
