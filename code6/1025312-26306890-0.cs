    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            this.port.Write("s");
            var InputData = this.port.ReadLine();
            if (!string.IsNullOrEmpty(InputData))
            {
                MessageBox.Show(InputData);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    } 
