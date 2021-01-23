    (File.Exists(Dts.Variables["User::DestinationExcelFilePath"].Value.ToString()))
    {
        File.Delete(Dts.Variables["User::DestinationExcelFilePath"].Value.ToString());
    }
    Dts.TaskResult = (int)ScriptResults.Success;
