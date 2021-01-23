    form.Shown += async (s, a) =>
    {
        try
        {
            await client.SendMailAsync(message);
            form.Close();
            MessageBox.Show("Test mail sent", "Success");
        }
        catch(Exception ex)
        {
            form.Close();
            string text = string.Format(
                "Error sending test mail:\n{0}",
                ex.Message);
            MessageBox.Show(text, "Error");
        }
    };
    form.ShowDialog();
