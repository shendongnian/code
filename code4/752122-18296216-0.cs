            //****TextBox for Total All****
            for (int y = 0; y <= 1; y++)
            {
                textBoxAllTotalContainer.Add(new List<TextBox>());
                textBoxAllTotalContainer[0].Add(new TextBox());
                textBoxAllTotalContainer[0][y].Size = new Size(175, 50);
                textBoxAllTotalContainer[0][y].Location = new Point(1150, 575);
                textBoxAllTotalContainer[0][y].TextChanged += new System.EventHandler(this.textBox_TextChanged);
                Controls.Add(textBoxAllTotalContainer[0][y]);
            }
