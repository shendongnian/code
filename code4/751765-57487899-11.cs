    Dim oReader As Reader.CemReaderClient = Reader.Client.Create
    If oReader.IsNotNothing Then
      Dim lIsReading = Await oReader.CallAsync(Function(Reader As Reader.CemReaderClient)
                                                 Me.ConfigFilePath = If(Me.ConfigFilePath, Reader.GetConfigFilePath)
                                                 Me.BackupDrive = If(Me.BackupDrive, Reader.GetBackupDrive)
                                                 Me.SerialPort = If(Me.SerialPort, Reader.GetSerialPort)
                                                 Me.LogFolder = If(Me.LogFolder, Reader.GetLogFolder)
                                                 Return Reader.GetIsReadingAsync
                                               End Function)
    End If
