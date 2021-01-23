        private void AddItem(Foo f)
        {
            ListViewItem lvi = new ListViewItem();
            StackPanel sp = new StackPanel();
            TextBlock tb_id = new TextBlock();
            tb_id.Text = f.Id;
            // Set your other proerty here
            sp.Children.Add(tb_id);
            TextBlock tb_fullInfo = new TextBlock();
            tb_fullInfo.Text = f.FullInfo;
            // Set your other property here
            sp.Children.Add(tb_fullInfo);
            lvi.Content = sp;
            listViewTest.Items.Add(lvi);
        }
