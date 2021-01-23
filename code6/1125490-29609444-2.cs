    form.Shown += async (s, a) =>
    {
        try
        {
            await client.SendMailAsync(message);
            form.Close();
        }
        catch(Exception ex)
        {
            // handle email error
        }
    };
    form.ShowDialog();
