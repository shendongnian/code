        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var timer = new System.Windows.Forms.Timer() { Interval = 50 };
            EventHandler handler = null;
            handler = (x, y) =>
            {
                timer.Tick -= handler;
                timer.Enabled = false;
                timer.Dispose();
                if (listView1.SelectedItems.Count < 1)
                {
                    MessageBox.Show("Please select an item first.");
                }
                else
                {
                    string name = listView1.SelectedItems[0].SubItems[0].Text;
                    Binddata(name);
                }
            };
            timer.Tick += handler;
            timer.Enabled = true;
        }
