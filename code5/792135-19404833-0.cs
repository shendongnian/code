        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e) {
            var item = ((ListView)sender).HitTest(e.Location);
            if (item != null) {
                // etc..
            }
        }
