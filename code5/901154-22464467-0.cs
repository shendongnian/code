    if (dr == DialogResult.Yes)
    {
        for (int i = 0; i < this.tabControl1.Controls.Count; i++)
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
                ctrlCombo.Text = string.Empty; // Or whatever the correct logic would be to clear it
            }
            else if ((ctrlPicture = ctrl as PictureBox) != null)
            {
                // Logic to clear a PictureBox called ctrlPicture
            }
            else if ((ctrlRadio = ctrl as RadioBox) != null)
            {
                // Logic to clear a RadioButton called ctrlRadio
            }
        }
    }
