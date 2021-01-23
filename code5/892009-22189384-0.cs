     for (int i = 0; i < 10; ++i)
            {
                RadListBoxItem item = new RadListBoxItem();
                RadCheckBoxElement checkBox = new RadCheckBoxElement();
                checkBox.Text = "Item " + i;
                checkBox.ToggleState = i % 2 == 0 ? Telerik.WinControls.Enumerations.ToggleState.On: Telerik.WinControls.Enumerations.ToggleState.Off;
                //remove this line if you dont want to close popup on checkbox checked
                checkBox.ToggleStateChanged += new StateChangedEventHandler(checkBox_ToggleStateChanged);
                item.Children.Add(checkBox);
                this.radComboBox1.Items.Add(item);
            }
