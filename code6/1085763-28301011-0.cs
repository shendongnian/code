    Label[,] Cell = new Label[8, 8];
    for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
                {    
                    Label tempLabel = new Label();
                    Cell[i,j] = tempLabel;
                    tempLabel.Text = (i + 1) + "" + (j + 1);
                    tempLabel.Location = new Point(j * 50 + 25, i * 50 + 25);
                    tempLabel.Click += new System.EventHandler(lbl_click);
                    tempLabel.Tag = new Tuple<int, int>(i, j);
                    this.Controls.Add(tempLabel);
                }
        }
    public void lbl_click(object sender, EventArgs e)
        {
                 Label label = sender as Label;
                 Tuple<int, int> position = label.Tag as Tuple<int, int>;
                 if(positon != null)
                 {
                     int i = position.Item1;
                     int j = position.Item2;
                     //do whatever with the coordinates
                 }
        }
