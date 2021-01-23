    async public static void WriteFile(string filename, string text)
    {
        StreamWriter file = new StreamWriter(filename);
        try
        {
            await file.WriteAsync(text);
        }
        catch (System.UnauthorizedAccessException)
        {
            MessageBox.Show("You have no write permission in that folder.");
        }
        catch (System.Exception e)
        {
            MessageBox.Show(e.Message);
        }
        file.Close();
    }
