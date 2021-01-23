    var radio = new RadioButton();
    radio.CheckedChanged +=new EventHandler(radio_CheckedChanged);
    radio.IsChecked = true;
    private void radio_CheckedChanged(object sender, EventArgs e)
    {
            if (radio.Checked)
            {
                MessageBox.Show("true");
            }
            else
            {
                MessageBox.Show("false");
            }
    }
