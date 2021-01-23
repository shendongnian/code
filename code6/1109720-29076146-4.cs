        protected void btn_Click(object sender, EventArgs e)
        {
            //Make sure only dynamic controls get selected for process
            foreach (Control cntrl in this.Form.Controls.OfType<RadioButton>().Where(x => x.ID.Contains("reason")))
            {
                bool option = ((RadioButton)cntrl).Checked;
            }
        }
