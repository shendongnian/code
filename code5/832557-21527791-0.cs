    private void OpenCommandLine(string XML_As_Param, string output)
    {
        try
        {
            Textfeld1.AppendText("\n\nTransformation started\n");
            MyBatchFile = @"transform.bat";
            XML_filename = @"" + XML_As_Param + "";
            XSL_filename = @"stylesheet.xsl";
            this.output = @"" + output + "";
            process = new Process { StartInfo = { Arguments = string.Format("{0} {1} {2}", XML_filename, XSL_filename, output) } };
            process.StartInfo.FileName = MyBatchFile;
            process.Start();
        }
        catch (Exception e)
        {
            Textfeld1.AppendText(e.StackTrace);
            Textfeld1.AppendText("\n");
            Textfeld1.AppendText(e.Message);
        }
        finally
        {
            process.Close();
        }
    }
