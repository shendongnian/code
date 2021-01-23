    public List<Label> drawLabel()
    {
        lstLable = new List<Label>();
        foreach (cOrderItem item in currOrder.OrderItems)
        {
            _lbl = new Label();
            _lbl.Width = 200;// (int)CanvasWidth;
            _lbl.BackColor = Color.AliceBlue;
            _lbl.Text = item.ProductInfo.ProductDesc;
            _lbl.Height = 20;
            _lbl.Dock = DockStyle.Top;
            
            //this is the event i want to define for drawign purpose.
            _lbl.Paint += new PaintEventHandler(LblOnPaint);
            
            lstLable.Add(_lbl);
    
        }
        return lstLable;
    }
    // The Paint event method
    private void LblOnPaint(object sender, PaintEventArgs e)
    {
        // Example code:
        
        var label = (Label)sender;
    
        // Create a local version of the graphics object for the label.
        Graphics g = e.Graphics;
    
        // Draw a string on the label.
        g.DrawString(label.Text, new Font("Arial", 10), Brushes.Blue, new Point(1, 1));
    }
