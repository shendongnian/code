      if (panel1.Visible){
                panel1.Visible = false;
                panel1.Enabled = false;         
                panel2.Dock = DockStyle.Fill;
            }
            else{
                panel1.Visible = true;
                panel1.Enabled = true;
                panel2.Dock = DockStyle.None;
                panel2.Location = new Point(15, 15);
                panel2.Height= //Original height before you run.
                panel2.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
            }
