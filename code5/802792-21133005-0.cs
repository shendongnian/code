            ComboBox cbTst = new ComboBox { Height = 30, Width = 100 };
            cbTst.SelectedValue = "{Binding SelectedDirection, Mode=TwoWay}";
            cbTst.SelectedValuePath = "Tag";
            cbTst.Items.Add(new ComboBoxItem { Content = "North", Tag = 0 });
            cbTst.Items.Add(new ComboBoxItem { Content = "East", Tag = 90 });
            cbTst.Items.Add(new ComboBoxItem { Content = "South", Tag = 180 });
            cbTst.Items.Add(new ComboBoxItem { Content = "West", Tag = 270 });
            Gridx.Children.Add(cbTst);
