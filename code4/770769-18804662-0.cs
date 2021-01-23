        private void listView1_Resize(object sender, EventArgs e) {
            this.BeginInvoke(new Action(() => {
                var lv = (ListView)sender;
                var w = 0;
                for (int ix = 0; ix < lv.Columns.Count - 1; ++ix) w += lv.Columns[ix].Width;
                w = Math.Max(0, lv.ClientSize.Width - w);
                lv.Columns[lv.Columns.Count - 1].Width = w;
            }));
        }
