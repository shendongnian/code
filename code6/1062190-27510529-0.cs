    public void Main()
    {
        if (File.Exists(Dts.Variables["PVR_file_path"].Value.ToString()))
        {
            Dts.TaskResult = ScriptResults.Success;
        }
        else
        {
            Dts.TaskResult = ScriptResults.Failure;
        }
    }
