        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            TabControl1.Items.Add(new TabItem() { TabIndex = 0, Header = "Tab 0" });
            TabControl1.Items.Add(new TabItem() { TabIndex = 1, Header = "Tab 1" });
            TabControl1.Items.Add(new TabItem() { TabIndex = 2, Header = "Tab 2" });
            TabControl1.Items.Add(new TabItem() { TabIndex = 3, Header = "Tab 3" });
        }
