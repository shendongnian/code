    using (TextWriter tw = File.CreateText("actors.txt"))
    {
       try
       {
          foreach (object o in ActorArrayList)
             tw.WriteLine(o.ToString());
          tw.Flush();
       }
       catch (Exception ex)
       {
          MessageBoxShow("Error saving file!");
       }
    }
