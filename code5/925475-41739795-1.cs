    Imports System.Configuration
    Imports System.Data.OracleClient
    Public Class DBConnection
        Dim v_connectionstring As String
        Public OracleConnect As New OracleClient.OracleConnection
        Public OracleCommand As New OracleClient.OracleCommand
        Public OraDataAdp As New OracleClient.OracleDataAdapter
        Public Oratrans As OracleClient.OracleTransaction
        Dim OraPara As New OracleParameterCollection
        Public title As String
        Dim v_clearParameter As Boolean = True
        Public response As MsgBoxResult
    
        ''' <summary>
        '''  Open Oracle Connection
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Connect()
            Try
                v_connectionstring = ReadSetting("DBString") 'for test default comment it
                'v_connectionstring = "SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=team-pc)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));uid=genmfg1;pwd=genmfg1;"
                If OracleConnect.State = ConnectionState.Open Then
                    OracleConnect.Close()
                End If
                OracleConnect.ConnectionString = v_connectionstring
                OracleConnect.Open()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub
    
        ''' <summary>
        '''  Close Oracle Connection if Open
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Disconnect()
            Try
                If OracleConnect.State = ConnectionState.Open Then
                    OracleConnect.Close()
                End If
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub
    
        ''' <summary>
        '''  Read Settings From Configuratiob File
        ''' </summary>
        ''' <param name="key"> Key name from Configuration File aap.config</param>
        ''' <returns> return keyvalue as string </returns>
        ''' <remarks></remarks>
        Private Function ReadSetting(ByVal key As String) As String
            Dim result As String
            Try
                Dim appSettings = ConfigurationSettings.AppSettings
                result = appSettings(key)
                If IsNothing(result) Then
                    result = "Not found"
                End If
                Return result
            Catch ex As Configuration.ConfigurationException
                Throw ex
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
    
        ''' <summary>
        '''  Clear oracle Paramter Collection of Coomand
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ClearParameter()
            Try
                OracleCommand.Parameters.Clear()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    
        ''' <summary>
        '''  Add Parameter For Procedure or Function any type of oracle command
        ''' </summary>
        ''' <param name="p_paraType">'I' for Input,'O' for Output and 'IO' for Input Output both,'R' For R</param>
        ''' <param name="p_paraName"> Name Of Parameter, same which is in declaration of Oracle </param>
        ''' <param name="p_paraDBType"> Name Of Parameter Typw, same which is in declaration of Oracle </param>
        ''' <param name="p_paraSize"> Size Of output Parameter/Field when p_paratype 'I' Size not consider </param>
        ''' <param name="p_paraval"> Parameter Value as Object but must be compitible with object </param>
        ''' <remarks> </remarks>
        Public Sub AddParameter(ByVal p_paraType As String, ByVal p_paraName As String, ByVal p_paraDBType As OracleType, ByVal p_paraSize As Integer, ByVal p_paraval As Object)
            ' OracleCommand.Parameters.Add
            Try
                If v_clearParameter Then
                    ClearParameter()
                    v_clearParameter = False
                End If
                'OracleCommand.Parameters.Add( p_paraName,p_paraDBType,p_paraSize,p_paraval)
                If p_paraType = "I" Then
                    OracleCommand.Parameters.Add(p_paraName, p_paraDBType).Value = p_paraval
                ElseIf p_paraType = "O" Then
                    OracleCommand.Parameters.Add(p_paraName, p_paraDBType, p_paraSize).Direction = ParameterDirection.Output
                ElseIf p_paraType = "IO" Or p_paraType = "OI" Then
                    OracleCommand.Parameters.Add(p_paraName, p_paraDBType, p_paraSize).Direction = ParameterDirection.InputOutput
                    OracleCommand.Parameters(p_paraName).Value = p_paraval
                ElseIf p_paraType = "R" Then
                    OracleCommand.Parameters.Add(p_paraName, p_paraDBType, p_paraSize).Direction = ParameterDirection.ReturnValue
                Else
                    Throw New Exception("Invalid Parameter Type")
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    
        ''' <summary>
        '''  Begin Transaction For Commit and Rollback Transaction
        ''' </summary>
        ''' <param name="p_isolvl"></param>
        ''' <remarks></remarks>
        Public Sub BeginTransaction(ByVal p_isolvl As System.Data.IsolationLevel)
            Try
                Oratrans = OracleConnect.BeginTransaction(p_isolvl)
                OracleCommand.Transaction = Oratrans
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    
        ''' <summary>
        ''' Commit DML command 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Commit()
            Try
                Oratrans.Commit()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    
        ''' <summary>
        ''' Rollback DML command
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Rollback()
            Try
                Oratrans.Rollback()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    
        ''' <summary>
        '''  Fill Dataset With command
        ''' </summary>
        ''' <param name="p_PrcName"> Oracle Procedure Name </param>
        ''' <param name="p_TableNames"> Name Of the Return Table </param>
        ''' <returns> Return Dataset From Store Procedure </returns>
        ''' <remarks></remarks>
        Public Function ExecuteSPReturnDatasetWithCommand(ByVal p_PrcName As String, ByVal p_TableNames As String()) As DataSet
            Dim _ds As DataSet = New DataSet
            Try
                Connect()
                OracleCommand.CommandText = p_PrcName
                OracleCommand.Connection = OracleConnect
                OracleCommand.CommandType = CommandType.StoredProcedure
                OraDataAdp = New OracleClient.OracleDataAdapter(OracleCommand)
                OracleCommand.ExecuteNonQuery()
                OraDataAdp.Fill(_ds)
                Try
                    For Each _tbstr As String In p_TableNames
                        _ds.Tables(0).TableName = _tbstr
                    Next
                Catch ex As Exception
                    Throw New Exception("No Of Return Table Does not match with Procedure")
                End Try
                Return _ds
            Catch ex As Exception
                Throw ex
            Finally
                v_clearParameter = True
                Disconnect()
            End Try
        End Function
    
        ''' <summary>
        '''  Execute Stored Procedure With Transaction
        ''' </summary>
        ''' <param name="p_prcname"> Oracle Procedure Name </param>
        ''' <remarks></remarks>
        Public Sub ExecuteSPFunWithTransaction(ByVal p_prcname As String)
            Try
                OracleCommand.CommandText = p_prcname
                OracleCommand.Connection = OracleConnect
                OracleCommand.CommandType = CommandType.StoredProcedure
                OracleCommand.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                v_clearParameter = True
            End Try
        End Sub
    
        ''' <summary>
        '''  Execute Sql Query as string
        ''' </summary>
        ''' <param name="p_Sqlqry"> sql query  for execute </param>
        ''' <remarks></remarks>
        Public Sub ExecuteSqlWithcommand(ByVal p_Sqlqry As String)
            Try
                Connect()
                OracleCommand.CommandText = p_Sqlqry
                OracleCommand.Connection = OracleConnect
                OracleCommand.CommandType = CommandType.Text
                OracleCommand.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                v_clearParameter = True
                Disconnect()
            End Try
        End Sub
    
        ''' <summary>
        '''  Return Scalar value from sql stmt
        ''' </summary>
        ''' <param name="p_Sqlqry"></param>
        ''' <returns> Object for all datatype compatibalite </returns>
        ''' <remarks></remarks>
        Public Function ExecuteSqlReturnScalarWithcommand(ByVal p_Sqlqry As String) As Object
            Dim _obj As Object
            Try
                Connect()
                OracleCommand.CommandText = p_Sqlqry
                OracleCommand.Connection = OracleConnect
                OracleCommand.CommandType = CommandType.Text
                _obj = OracleCommand.ExecuteScalar()
            Catch ex As Exception
                Throw ex
            Finally
                v_clearParameter = True
                Disconnect()
            End Try
            Return _obj
        End Function
    
        ''' <summary>
        '''  Execute Sp/Function With Command
        ''' </summary>
        ''' <param name="p_prcname"> Procedure and Function name </param>
        ''' <remarks></remarks>
        Public Sub ExecutSPFunPWithcommand(ByVal p_prcname As String) 
            Try
                Connect()
                OracleCommand.CommandText = p_prcname
                OracleCommand.Connection = OracleConnect
                OracleCommand.CommandType = CommandType.StoredProcedure
                OracleCommand.ExecuteNonQuery()
            Catch ex As Exception
                Throw ex
            Finally
                v_clearParameter = True
                Disconnect()
            End Try
        End Sub
    
        ''' <summary>
        '''  Get Parameter Value From Parameter list as out parameter
        ''' </summary>
        ''' <param name="p_parametername"></param>
        ''' <returns> return value as object</returns>
        ''' <remarks></remarks>
        Public Function GetParameterValue(ByVal p_parametername As String) As Object
            Try
                Return OracleCommand.Parameters(p_parametername).Value
            Catch ex As Exception
                Return Nothing
            Finally
            End Try
        End Function
    End Class
