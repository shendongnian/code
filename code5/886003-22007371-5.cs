    private void timer1_Tick(object sender, EventArgs e)
    {
        StreamWriter writer = File.AppendText(FileNameTextBox.Text);
        writer.WriteLine(String.Format("{0},{1},{2}", DateTime.Now.ToString("hh:mm:ss"), BigMotorTextBox.Text, SmallMotorTextBox.Text)); 
        writer.Close();
    }
