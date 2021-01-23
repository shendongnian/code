        List<Control> ctrls = new List<Control>(panel.Controls)
        foreach (Control c in ctrls)
        {
            if(c is Button)
            {
                 c.Click -= new EventHandler(this.b_Click);
                 panel.Controls.Remove(c);
                c.Dispose();
            }
        }
