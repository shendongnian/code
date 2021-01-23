        For Each OneProcess As Process In localAll
          Try
            ' Extract the program's icon
            Dim ico As Icon = Icon.ExtractAssociatedIcon(OneProcess.MainModule.FileName)
            Dim pID = OneProcess.Id.ToString
            imgID = pID
            ImageList1.Images.Add(pID, ico)
            Dim row As String() = New String() { _
                OneProcess.ProcessName, _
                OneProcess.MainModule.FileVersionInfo.FileName}
            DataGridView1.Rows.Add(row)
         Catch ex As Exception
           Debug.Print("Error: " & ex.Message)
         End Try
        Next
