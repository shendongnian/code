    GroupBox gbFreeCust = new GroupBox() 
        { 
            Dock= DockStyle.Top, 
            Text = item.CatName, 
            AutoSize = true, 
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly,
            Padding = new System.Windows.Forms.Padding(0),
            MinimumSize = new Size(0,0)
        };
    pnlFreeCust.Controls.Add(gbFreeCust);
