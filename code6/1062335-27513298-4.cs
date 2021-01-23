    public void Main()
    { 
    string targetfile = Dts.Variables["PRC_file_path"].Value.ToString();
      
     if (File.Exists(targetfile))
                {
                    Dts.Variables["file_exists"].Value = true;
                }
                else
                {
                     Dts.Variables["file_exists"].Value = false;
                }
    Dts.TaskResult = (int)ScriptResults.Success;
    }
