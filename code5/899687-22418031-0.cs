    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
    	if (starmap == true)
    	{
    		GraphicsUnit unit = GraphicsUnit.Pixel;
    
    		foreach (Image pic in imgPos)
    		{
    			Rectangle imgRect = pic.GetBounds(ref unit);
    			if (imgRect.Contains(this.PointToClient(e.Location)))
    			{
    			    MessageBox.Show("Clicked on image.");
    			}
    		}
    	}
    }
