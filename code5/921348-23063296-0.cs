    private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var itemSearched = textBox1.Text;
                int itemCount = 0;
                foreach (var item in listBox1.Items)
                {
                    if (item.ToString().IndexOf(itemSearched,StringComparison.InvariantCultureIgnoreCase)!=-1)
                    {
                        listBox1.SelectedIndex = itemCount;
                        break;
                    }
                    itemCount++;
                }
            }
        }
