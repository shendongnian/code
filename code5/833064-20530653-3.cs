    Label myLabel1;
    Label myLabel2;
    /// <summary>
    /// Add the dynamic controls to the page before the viewstate is 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
    /// <summary>
    /// Ensure first time loads properly setup the page.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    { 
      if (!Page.IsPostBack)
      { 
        //Remove the session when first time page loads.
        Session.Remove("clicks");
        Session.Remove("clicks2");
      
        //Set the Text Boxes and lables to zero.
        BuildTextBoxes(0, 0);
      }
    }
    /// <summary>
    /// Add any new text boxes to the screen.
    /// </summary>
    /// <param name="rowCount1">The total number of text boxes in the first group.</param>
    /// <param name="rowCount2">The total number of text boxes in the second group.</param>
    private void BuildTextBoxes(int rowCount1, int rowCount2)
    {
      var panel1Count = Panel1.Controls.Count;    //Current number of text boxes
      panel1Count--;                              //Remove the Label control from the count
      for (int i = panel1Count; i < rowCount1; i++)
      {
        TextBox TxtBoxU = new TextBox();
        TxtBoxU.ID = "TextBox1U" + i.ToString();  //Ensure a globally unique name.
        Panel1.Controls.Add(TxtBoxU);             //Add the labels and textboxes to the Panel.
      }
      myLabel1.Text = rowCount1.ToString();
      var panel2Count = Panel2.Controls.Count;    //Current number of text boxes
      panel2Count--;                              //Remove the Label control from the count
      for (int i = panel2Count; i < rowCount2; i++)
      {
        TextBox TxtBoxU = new TextBox();          
        TxtBoxU.ID = "TextBox2U" + i.ToString();  //Ensure a globally unique name;
        Panel2.Controls.Add(TxtBoxU);             //Add the labels and textboxes to the Panel.
      }
      myLabel2.Text = rowCount2 + "";
    }
    /// <summary>
    /// Add another textbox to the first group.
    /// </summary>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
      int rowCount1 = 0;
      //initialize a session.
      rowCount1 = Convert.ToInt32(Session["clicks"]);
      rowCount1++;
      //In each button click save the numbers into the session.
      Session["clicks"] = rowCount1;
      BuildTextBoxes(rowCount1, Convert.ToInt32(Session["clicks2"]));
    }
    /// <summary>
    /// Add another textbox to the second group.
    /// </summary>
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
