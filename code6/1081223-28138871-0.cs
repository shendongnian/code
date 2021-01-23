            for (int i = 0; i < rowCount; i++)
            {
                // Create objects 
                LinkLabel Linklabel1 = new LinkLabel();
                Linklabel1.Text = ds.Tables[0].Rows[i]["code"].ToString();
                Linklabel1.Height = 40;
                Linklabel1.Width = 100;
                Linklabel1.Location = new Point((i + 1) * 10 + (i * Linklabel1.Width), 50);
                tabControl1.TabPages[0].Controls.Add(Linklabel1);
            }
