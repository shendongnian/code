       private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbCalls.Items.Count > 0)
                lbCalls.Items.RemoveAt(lbCalls.SelectedIndex);
            ChangeButtonStatus();
        }
        void ChangeButtonStatus()
        {
            if (lbCalls.Items.Count > 0)
                btnNextCall.Enabled = true;
            else
                btnNextCall.Enabled = false;
        }
