    foreach (MSExcel.WorkbookConnection cnn in wb.Connections)
    {
        if (cnn.Type.ToString() == "xlConnectionTypeODBC")
        {
            cnn.ODBCConnection.BackgroundQuery = false;
        }
        else
        {
            cnn.OLEDBConnection.BackgroundQuery = false;
        }
    }
