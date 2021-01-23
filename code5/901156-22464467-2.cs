    private void ClearControls(Control parentControl)
    {
        foreach (Control ctrl in parentControl.Controls)
        {
            TextBox ctrlText;
            ComboBox ctrlCombo;
            PictureBox ctrlPicture;
            RadioButton ctrlRadio;
            // Pay careful attention to the parentheses...
            if ((ctrlText = ctrl as TextBox) != null)
            {
                ctrlText.Text = string.Empty;
            }
            else if ((ctrlCombo = ctrl as ComboBox) != null)
            {
                ctrlCombo.SelectedIndex = -1;
            }
            else if ((ctrlPicture = ctrl as PictureBox) != null)
            {
                // Logic to clear a PictureBox called ctrlPicture
            }
            else if ((ctrlRadio = ctrl as RadioBox) != null)
            {
                // Logic to clear a RadioButton called ctrlRadio
            }
            else if (ctrl.Controls.Count > 0)
            {
                ClearControls(ctrl); // Recursively clear contained controls.
            }
        }
    }
