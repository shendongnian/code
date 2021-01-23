    private void CreateOrLoadTextBoxes(int numTextBoxes)
    {
		List<TextBox> lstControls ;
        
		//if its the first time the controls need to be created
        if(Session["lstTitleControls"] == null)
        {
			lstTbTitles = new List<TextBox>(numTextBoxes) ;
			lstTbAuthors = new List<TextBox>(numTextBoxes) ;
			//create the controls for Book Titles
       		for (int i = 1; i <= numTextBoxes; i++)
        	{
				TextBox tb = new TextBox();
				tb.Text = "Book  " + i.ToString() + " Title";
				tb.ID = "TextBoxTitle" + i.ToString();
				lstTbTitles.Add(tb) ;
			} 
			//Create the controls for Author
       		for (int i = 1; i <= numTextBoxes; i++)
        	{
				TextBox tb2 = new TextBox();
				tb2.Text = "Book  " + i.ToString() + " Author";
				tb2.ID = "TextBoxAuthor" + i.ToString();
				lstTbAuthors.Add(tb2) ;
			} 
			//store the created controls on ViewState asociated with the key "lstTitleControls" and "lstAuthorControls"
			// each time you store or access a ViewState you a serialization or deserialization happens which is expensive/heavy
			Session["lstTitleControls"] = lstTbTitles ;
			Session["lstAuthorControls"] = lstTbAuthors ;
		}
		else
		{
			//restore the list of controls from the ViewState using the same key
			lstTbTitles = (List<TextBox>) Session["lstTitleControls"];
			lstTbAuthors = (List<TextBox>) Session["lstAuthorControls"];
			numTextBoxes = lstTbTitles.Count() ;
		}
		//at this moment lstTbTitles and lstTbAuthors has a list of the controls that were just created or recovered from the ViewState
		
        //now add the controls to the page
		for (int i = 1; i <= numTextBoxes; i++)
		{
        	pnlBooks.Controls.Add(lstTbTitles[i]);
        	pnlBooks.Controls.Add(lstTbAuthors[i]);
        	pnlBooks.Controls.Add(new LiteralControl("<br />"));
		}
    }
	protected void Page_Load(object sender, EventArgs e)
	{
		CreateOrLoadTextBoxes(10) ;
	}
  
