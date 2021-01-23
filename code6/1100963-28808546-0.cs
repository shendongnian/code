     for (int i = 0; i < Enum.GetValues(typeof(DayOfWeek)).Length; i++)
            {
                StackPanel panel = new StackPanel() { Orientation = Orientation.Horizontal };
                if (i < 4)
                {
                    panel.Children.Add(new CheckBox());
                }
                else
                {
                    panel.Children.Add(new RadioButton() { GroupName = "SameGRoupName" });
                }
                panel.Children.Add(new TextBlock() { Text = ((DayOfWeek)i).ToString() });
                uiList.Items.Add(panel);
            }
