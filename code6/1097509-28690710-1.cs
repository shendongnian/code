		private void Button_Click(object sender, RoutedEventArgs e)
		{
			listBox1.Items.Add("New Item");
			AutoScrollToCurrentItem(listBox1, listBox1.Items.Count);
		}
