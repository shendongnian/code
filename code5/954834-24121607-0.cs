     YourConnectionString
     YourSLQTable
     Your  SQL Columns: col1, col2, coln
     Your Column Valuess: @cdata1, cdata2, cdatan
     UniqueValue: the columns(s) that make your SQL table unique
     Note that parameter values must be supplied in the order they are used in the SQL statement, not in the named list, ex. New String() {"UV", "cdata1", "cdata2"}, _
                    
    Public Shared connString As String = _
        Configuration.ConfigurationManager.ConnectionStrings("xls").ConnectionString
    Public Shared connStringX As String = _
       Configuration.ConfigurationManager.ConnectionStrings("xlsx").ConnectionString
    Public Shared Sub ImportExcelFile(ByRef Filepath As String)
        Dim ConnectionString = IIf(Filepath.EndsWith("xlsx"), connStringX, connString)
        Try
            Using axsCon = New OleDbConnection("YourConectionString")
                axsCon.Open()
                Using m_connexcel As OleDbConnection = _
                    New OleDbConnection(String.Format(ConnectionString, Filepath))
                    m_connexcel.Open()
                    Dim Sheetname As String = GetFirstExcelWorksheetName(m_connexcel, Filepath)
                    Using cmd As OleDbCommand = New OleDbCommand("SELECT  * FROM [" & Sheetname & "]", m_connexcel)
                        Using oRDR As OleDbDataReader = cmd.ExecuteReader
                            While (oRDR.Read)
                                If Common.GetScalar(axsCon, "SELECT Count(*) FROM YourSQLTable WHERE [UniqueValue]=@UV ", _
                                    New String() {"UV"}, New Object() {oRDR.GetValue(0)}) = 0 Then
                                    Common.ExecuteSQL(axsCon, _
                                        "INSERT INTO YouSQLTable(col1, col2, coln) " & _
                                        "VALUES(@C1,@C2,@CN)", New String() {"Cdata1", "Cdata2", "CdataN"}, _
                                            New Object() {oRDR.GetValue(0), oRDR.GetValue(1), oRDR.GetValue(2)})
                                Else
                                    Common.ExecuteSQL(axsCon, _
                                        "UPDATE YourSQLTable SET col1=@cdata1,col2=@cdata2,UNiqueValue=@UV " & _
                                        "WHERE UniqueValue=@UV", New String() {"UV", "cdata1", "cdata2"}, _
                                            New Object() {oRDR.GetValue(1), oRDR.GetValue(2), oRDR.GetValue(0)})
                                End If
                            End While
                        End Using
                    End Using
                    m_connexcel.Close()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
