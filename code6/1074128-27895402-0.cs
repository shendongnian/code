            Panel panel1 = new Panel();
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(789, 424);
            panel1.TabIndex = 0;
            this.Controls.Add(panel1);
            for (int i = 0; i < 20; i++) 
            {
                TextBox Box = new TextBox();
                Box.Location = new System.Drawing.Point(55, 12+(20*i));
                Box.Name = "Box"+i.ToString();
                Box.Size = new System.Drawing.Size(100, 20);
                panel1.Controls.Add(Box);
            }
            for (int i = 0; i < 20; i++) 
            {
                panel1.Controls["Box" + i].Text = "TextBox " + i;
            }
