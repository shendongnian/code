    try
    {
        string fileToDownload = MapPath(@"~\Sample.txt");
        string fileToRead = MapPath(@"~\FileNotExist.txt");
        try
        {
            //Section 1
            try
            { 
                // try to read the file which does not exist to raise the exception
                StreamReader ss = new StreamReader(fileToRead);
            }
            catch (IOException IoEx)
            {
                // Just for sample exception
            }
            // Section 2 code block still execute because exception handled by upper try catch block 
            //Section 2
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=SampleTemplate.txt");
            Response.ContentType = "text";
            Response.WriteFile(fileToDownload);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (System.Threading.ThreadAbortException abrtEx)
        {
          // do not treat this exception as Exception
        }
        //Section 3 Code block not executing even after exception handeled by ThreadAbortException 
        //Section 3
         string test = "Do futher process after sample downloaded";
    }
    catch (Exception ex) // Outer Catch Block
    {
        throw ex;
    }
    }
