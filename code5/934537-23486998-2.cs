	Random rand = new Random();
	int label_amount = 15;
	int xCoor;
	int yCoor;
	
	private void btnRun_Click(object sender, EventArgs e)
	{
		//set the button to show  the labels 
		for (int x = 0; x < label_amount; x++)
		{
			xCoor = coor.Next(0, 750);
			yCoor = coor.Next(0, 500);
				
			Label nodeLabel = new Label();	
			nodeLabel.Text = value + " " + xCoor + "," + yCoor;
			nodeLabel.AutoSize = true;
			nodeLabel.Location = new Point(xCoor + 10, yCoor + 5);
			// Add your label to whatever you're adding it
		}
	}
