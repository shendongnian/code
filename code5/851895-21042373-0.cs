        private void resultButton_Click(object sender, EventArgs e)
        {
            using(ResultForm rf = new ResultForm(this))
            { 
              rf.ShowDialog();
            }
            this.Enabled = false;
        }
