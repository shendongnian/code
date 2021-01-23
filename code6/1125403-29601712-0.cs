        private void DisableAll_Click(object sender, EventArgs e)
        {
            EnabledPanelContents(this.panel1, false);
        }
        private void EnabledPanelContents(Panel panel, bool enabled)
        {
            foreach (Control item in panel.Controls)
            {
                item.Enabled= enabled;
            }
        }
