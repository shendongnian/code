    comboBox1.TextChanged += HandleOnTextChanged;
    
    private void HandleOnTextChanged(object sender, EventArgs e)
        {
            //Loop SRtier1 Array to ComboBox
            for (int i = 0; i < SRtier1.Length; i++)
            {
                if (SRcmb_tier1.Text != SRtier1[i])
                {
                    MessageBox.Show("Please select one of the options provided.");
                }
            }
        }
