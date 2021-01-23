    protected void page_init(object sender, EventArgs e)
    {
      myLabel1 = new Label();
      myLabel2 = new Label();
      Panel1.Controls.Add(myLabel1);
      Panel2.Controls.Add(myLabel2);
      var box1Count = 0;
      box1Count = Convert.ToInt32(Session["clicks"]);
      var box2Count = 0;
      box2Count = Convert.ToInt32(Session["clicks2"]);
      
      BuildTextBoxes(box1Count, box2Count);
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
      
      
      if (!Page.IsPostBack)
      {
        
        //Remove the session when first time page loads.
        Session.Remove("clicks");
        Session.Remove("clicks2");
        BuildTextBoxes(0, 0);
      }
    }
    private void BuildTextBoxes(int rowCount1, int rowCount2)
    {
      for (int i = Panel1.Controls.Count - 1; i < rowCount1; i++)
      {
        TextBox TxtBoxU = new TextBox();
        TxtBoxU.ID = "TextBox1U" + i.ToString();
        //Add the labels and textboxes to the Panel.
        Panel1.Controls.Add(TxtBoxU);
      }
      myLabel1.Text = rowCount1 + "";
      for (int i = Panel2.Controls.Count - 1; i < rowCount2; i++)
      {
        TextBox TxtBoxU = new TextBox();
        TxtBoxU.ID = "TextBox2U" + i.ToString();
        //Add the labels and textboxes to the Panel.
        Panel2.Controls.Add(TxtBoxU);
      }
      myLabel2.Text = rowCount2 + "";
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
      int rowCount1 = 0;
      //initialize a session.
      rowCount1 = Convert.ToInt32(Session["clicks"]);
      rowCount1++;
      //In each button clic save the numbers into the session.
      Session["clicks"] = rowCount1;
      BuildTextBoxes(rowCount1, Convert.ToInt32(Session["clicks2"]));
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
      int rowCount2 = 0;
      //initialize a session.
      rowCount2 = Convert.ToInt32(Session["clicks2"]);
      rowCount2++;
      //In each button clic save the numbers into the session.
      Session["clicks2"] = rowCount2;
      BuildTextBoxes(Convert.ToInt32(Session["clicks"]), rowCount2);
    }
