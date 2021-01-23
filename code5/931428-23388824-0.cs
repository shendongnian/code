    public void getFileNoDuplicate()
    {
        try
        {
            //objDic.Add(_InitfileName + statInt, string.Empty);
            // _fileName = _InitfileName + stateDate;
            _fileName = _InitfileName + statInt;
            objDic.Add(FileManager2.Write(_fileName, "txt", "hello", false), string.Empty);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
