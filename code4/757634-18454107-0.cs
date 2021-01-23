        private void tabControl1_ControlRemoved(object sender, ControlEventArgs e) {
            this.BeginInvoke(new Action(() => {
                MessageBox.Show(tabControl1.TabCount.ToString());
            }));
        }
