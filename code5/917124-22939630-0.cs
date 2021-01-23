    while (reader.Read())
                {
                    b = new Button();
                    b.Text = "Delete";
                    b.Name = reader["Username"].ToString();
                    b.BackColor = Color.DarkOrange;
                    b.ForeColor = Color.Black;
                    b.Location = new Point(240, Y);
                    b.FlatStyle = FlatStyle.Flat;
                    ***b.Click += new EventHandler(b_Click);***
                    LB.Add(b);
                }
