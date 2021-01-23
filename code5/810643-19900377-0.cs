                int numControls = this.Controls.Count;
                List<String> txtValues=new List<string>();                
                for (int i = 0; i < numControls; i++)
                {
                   if (this.Controls[i] is TextBox)
                    {
                        TextBox myTextBox = this.Controls[i] as TextBox;
                        txtValues.Add(myTextBox.Text.ToString());                       
                    }
                }
