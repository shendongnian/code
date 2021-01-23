    private void toolStripButton1_CheckStateChanged(object sender, EventArgs e)
    {
        // Checked means it's clicked
        if (toolStripButton1.Checked)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.Open();
                toolStripButton1.Text = "Close Port";
            }
        }
        else
        {
            if (serialPort1.IsOpen())
            {
                serialPort1.Close();
                toolStripButton1.Text = "Open Port";
            }
        }
    }
