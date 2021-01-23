    public void Main()
    { 
    string targetfile = Dts.Variables["PRC_file_path"].Value.ToString()
      try{
     if (File.Exists(targetfile))
                {
                    Dts.Variables["file_exists"].Value = True;
                }
                else
                {
                     Dts.Variables["file_exists"].Value = False;
                }
          
         Dts.TaskResult = (int)ScriptResults.Success;
         }
     catch (Exception Ex)
         {
         Dts.TaskResult = (int)ScriptResults.Failure;
         }
    }
