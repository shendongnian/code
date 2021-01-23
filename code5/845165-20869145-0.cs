    // You must get an graphic reference to picture box
    
    private void Pic_Paint(object sender, PaintEventArgs e)
    {
        PaintBackground(e.Graphics);
    }
    
    // bellow code is for example and draw an image
    private void PaintBackground(Graphics g)
    {
    	//Draw image
    	int x = 0;
    	int y = 0;
    	Image img = null;
    	img = global::Billing.ClientUI.Properties.Resources.BillingBackgroundEn;
    	x = Pic.ClientRectangle.Width - img.Width - 20;
    	y = Pic.ClientRectangle.Height - img.Height - 20;
    	((Bitmap)img).MakeTransparent();
    	g.DrawImageUnscaled(img, x, y);
    }
    
    // at final if you get Graphics context then can DrawLine, Curve, Image ...
    // See System.Drawing.Graphics for more info ...
