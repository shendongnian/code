    private void AddPicturesToGroupBox(List<PictureBox> pictureBoxes)
    {
    	Panel myPanel = new Panel();
    	myPanel.Dockstyle = Dockstyle.Fill;
    	myPanel.AutoScroll = true; //this allows the panel to display scrollbars when it needs to
    
    	foreach (var pic in pictureBoxes)
    	{
    		myPanel.Controls.Add(pic); //put your pictures onto the panel
    	}
    
    	this.gbFacets.Controls.Clear();
    	this.gbFacets.Controls.Add(myPanel); //put your panel inside the Groupbox
    }
