    try
    {
        //your code here
            using (process = new Process())
                {
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Arguments = string.Join(" ", arg1, arg2, arg3);
                    process.StartInfo.Verb = "runas";
                    process.Start();
        
                }
        //end code
    }
    catch(System.ComponentModel.Win32Exception)
    {
    //Do Something or Leave it empty to swallow the exception
    }
