        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    //nothing to do.. or you can, if you want.. :)
                    break;
                case 1:                    
                    tbFName.Focus();
                    break;
            }
        }
