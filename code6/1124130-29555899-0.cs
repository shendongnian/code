    for (int i = 0; i < 5; i++)
            {
                Button newPanelButton = new Button();
                newPanelButton.Name = "txtRuntime" + i;
                newPanelButton.Text = "Runtime"+i;
                newPanelButton.Location = System.Drawing.Point.Add(new Point(4 + i * 307, 4), new Size(20, 20));// here make use of your logic.
                
                this.Controls.Add(newPanelButton);
            }
