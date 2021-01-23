            CheckedListBox ClistBox1 = new CheckedListBox();
            ClistBox1.FormattingEnabled = true;
            ClistBox1.Location = new System.Drawing.Point(12, 12);
            ClistBox1.Name = "listBox1";
            ClistBox1.Size = new System.Drawing.Size(278, 290);
            ClistBox1.TabIndex = 0;
            this.Controls.Add(ClistBox1);
            for (int i = 0; i < 20; i++)
            {
                ClistBox1.Items.Add("Box" + i, true); //Second parameter is "Checked" true or false
            }  
