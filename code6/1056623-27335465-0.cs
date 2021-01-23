	protected void Page_Init(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			//Remove the session when first time page loads.
			Session.Remove("clicks");
			Response.Write(Session["clicks"]);
		}
		else { 
		//initialize a session.
		int rowCount = Convert.ToInt32(Session["clicks"]);
		rowCount++;
		//In each button clic save the numbers into the session.
		Session["clicks"] = rowCount;
			Panel1.Controls.Clear();
		//Create the textboxes and labels each time the button is clicked.
			for (int i = 1; i <= rowCount; i++)
			{
				TextBox TxtBoxU = new TextBox();
				TextBox TxtBoxE = new TextBox();
				Label lblU = new Label();
				Label lblE = new Label();
				TxtBoxU.ID = "TextBoxU" + i.ToString();
				TxtBoxE.ID = "TextBoxE" + i.ToString();
				lblU.ID = "LabelU" + i.ToString();
				lblE.ID = "LabelE" + i.ToString();
				lblU.Text = "User " + (i).ToString() + " : ";
				lblE.Text = "E-Mail : ";
				//Add the labels and textboxes to the Panel.
				Panel1.Controls.Add(lblU);
				Panel1.Controls.Add(TxtBoxU);
				Panel1.Controls.Add(lblE);
				Panel1.Controls.Add(TxtBoxE);
			}
		}
	}
