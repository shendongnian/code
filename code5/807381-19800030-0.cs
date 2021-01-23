        private void internalModsChkAll_CheckedChanged(object sender, EventArgs e)
        {
            checkAll(internalModsChkAll, internalModsChkList);
        }
        public void checkAll(CheckBox from, CheckedListBox to) 
        {
            if (from.Checked == true)
            {
                for (int i = 0; i < to.Items.Count; i++)
                {
                    to.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < to.Items.Count; i++)
                {
                    to.SetItemChecked(i, false);
                }
            }
        }
