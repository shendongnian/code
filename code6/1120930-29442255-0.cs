        {
            
            TabPage t = new TabPage("new " + 1);
            tabControl1.TabPages.Add(t);
            tabControl1.SelectedTab = t;
            RichTextBox T2 = new RichTextBox();
            t.Controls.Add(T2);
            T2.Dock = DockStyle.Left;
            T2.Enabled = true ;
            RichTextBox T = new RichTextBox();
            t.Controls.Add(T);
            T2.Dock = DockStyle.Right;
            var AdjustedSize = T2.Size;
            AdjustedSize.Width = t.Size.Width * 2 / 3;
            T2.Size = AdjustedSize;
            T.Font = new Font("Microsoft San Serif", 11);
            Random R = new Random();
            int RandomNumberHere = R.Next(1000, 100000);
            T.Text = "Welcome, type your text...";
            T.Select();
            
        }
