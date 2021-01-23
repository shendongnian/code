    public void Main()
    {
        if (File.Exists(Dts.Variables["PVR_file_path"].Value.ToString()))
        {
            Dts.TaskResult = (int)ScriptResults.Success;
        }
        else
        {
            Dts.TaskResult = (int)ScriptResults.Failure;
        }
    }
