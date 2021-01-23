    private void usePort_Click(object sender, EventArgs e)
    {
        someStuff();
    }
    private void ports_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            someStuff();
        }
    }
	
	private void someStuff()
	{
	    try
        {
            port = new SerialPort((string)ports.SelectedItem, 9600);
            portUsedLabel.Text = (string)ports.SelectedItem;
            String buffer = "";
            String tellArduino = "food";    // test value
            port.Open();
            port.WriteLine(tellArduino);
            for (int x = 0; x < tellArduino.Length; x++)
            {
                buffer += port.ReadLine();
            }
            ports.Items.Add(buffer);
            port.Close();
        }
        catch { //stuff }
	}
