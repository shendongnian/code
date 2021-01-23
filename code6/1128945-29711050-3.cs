    if (e.KeyCode == Keys.Enter)
    {
        try
        {
            int input = Convert.ToInt32(tbInput.Text);
            ...
        }
        catch (FormatException)
        {
            MessageBox.Show("Input was in an invalid format.");
        }
        catch (OverflowException)
        {
            MessageBox.Show("The input was outside the valid range for integers.");
        }
        catch (IOException)
        {
            MessageBox.Show("Error with input");
        }
    }
