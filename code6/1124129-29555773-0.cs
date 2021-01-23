    StreamReader menu = new StreamReader("database.txt");
            int repetition = 0;
            while (!menu.EndOfStream)
            {
                Button dynamicbutton = new Button();
                dynamicbutton.Click += new System.EventHandler(menuItem_Click);
                dynamicbutton.AutoSize = true;
                dynamicbutton.Text = menu.ReadLine();
                dynamicbutton.Visible = true;
                dynamicbutton.Location = new Point(4 + repetition * 307, 4);
                dynamicbutton.Height = 24;
                dynamicbutton.Width = dynamicbutton.Text.Length * 20;
                dynamicbutton.BackColor = Color.FromArgb(0, 0, 0);
                dynamicbutton.ForeColor = Color.White;
                dynamicbutton.Font = new Font("Arial", 7);
                dynamicbutton.Show();
                splitContainer1.Panel1.Controls.Add(dynamicbutton);
                repetition++;
            }
            menu.Close();
