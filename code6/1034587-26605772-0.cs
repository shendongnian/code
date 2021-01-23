        private void btnFormat_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                Form testform = ActiveMdiChild;
                Control cont = testform.ActiveControl;
                if (cont is TextBox)
                {
                    //((TextBox)cont).Text = "Nasir Khan";
                    FontDialog fontDialog1 = new FontDialog();
                    // Show the dialog.
                    DialogResult result = fontDialog1.ShowDialog();
                    // See if OK was pressed.
                    if (result == DialogResult.OK)
                    {
                        // Get Font.
                        Font font = fontDialog1.Font;
                        ((TextBox)cont).Font = font;
                    }
                }
            }
        }
