    if (e.KeyCode == Keys.Enter)
    {
        try
        {
            int input = int.Parse(tbInput.Text);
            ...
        }
        catch (FormatException)
        {
            MessageBox.Show("Input was in an invalid format.");
        }
        catch (IOException)
        {
            MessageBox.Show("Error with input");
        }
    }
