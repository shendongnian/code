    private void WriteArrayList()
    {
        TextWriter tw = null;
        try
        {
            tw = File.CreateText("actors.txt");
            foreach (object o in ActorArrayList)
                tw.WriteLine(o.ToString());
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error saving file!");
        }
        finally
        {
            if(tw != null)
                tw.Close();
        }
    }
