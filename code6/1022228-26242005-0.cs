     foreach (var itm in shuffleRadio)
                {
                    RadioButton ra = new RadioButton();
                    ra.Content = itm.Content.ToString();
                    ra.GroupName = "Group1";
                    ra.Checked += RadioButton_Checked;
                    Stack1.Children.Add(ra);
                }
