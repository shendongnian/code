    private void Go2_Click(object sender, EventArgs e)
    {
        try
        {
            int[,] i_Array;
            int result1 = int.Parse(textBox3.Text);
            int result2 = int.Parse(textBox4.Text);
            i_Array = new int[result1, result2];
            int result3 = int.Parse(textBox5.Text);
            int total = 0;
            for (int i = 0; i < i_Array.Length; i++)
            {
                total += result3;
                textBox6.Text = Convert.ToString(total);
            }
        }
        catch (FormatException e)
        {
            // Try to read the message from user settings
            string errorMessage = Settings1.Default.StringIsNotAnInt;
            // If there wasn't a setting, then use the default error message
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                errorMessage = e.Message;
            }
            // Show the message to the user
            MessageBox.Show(errorMessage);
        }
    }
