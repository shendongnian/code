    async public static void WriteFile(string filename, string text)
    {
        StreamWriter file = null;
        try
        {
            file = new StreamWriter(filename);
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
        finally
        {
            if (file != null) file.Close();
        }
    }
