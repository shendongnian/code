        try
        {
           using (StreamWriter w = new StreamWriter(fs))
           {
               w.Write("** (Line) " + someValue + " **" + Environment.NewLine);                       
               w.Flush();                       
           }
        }
        catch(Exception ex)
        {
            //exception handling code here
        }
        finally
        {
           //any clean up code here. The using statement makes it unnecessary for the streamwriter
        }
