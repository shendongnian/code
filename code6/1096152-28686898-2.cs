    Imports log4net
    Imports log4net.Core
    Imports log4net.Layout
    Imports log4net.Appender
    Imports log4net.Repository.Hierarchy
    Public Class DbAppender
      Inherits AdoNetAppender
      Public Sub New()
        MyBase.CommandText = Me.CommandText
        MyBase.BufferSize = 1
        Me.Parameters.ForEach(Sub(Parameter As DbParameter)
                                MyBase.AddParameter(Parameter)
                              End Sub)
        Me.ActivateOptions()
      End Sub
      Protected Overrides Function CreateConnection(ConnectionType As Type, ConnectionString As String) As IDbConnection
        Return MyBase.CreateConnection(GetType(System.Data.SqlClient.SqlConnection), "Data Source=C52893-G\OIT;Initial Catalog=Logger;Persist Security Info=True;User ID=oit;Password=different-table")
      End Function
      Private Overloads ReadOnly Property CommandText As String
        Get
          Dim _
            sColumns,
            sValues As String
          sColumns = Join(Me.Parameters.Select(Function(P As DbParameter) P.DbColumn).ToArray, ",")
          sValues = Join(Me.Parameters.Select(Function(P As DbParameter) P.ParameterName).ToArray, ",")
          Return COMMAND_TEXT.ToFormat(sColumns, sValues)
        End Get
      End Property
      Private ReadOnly Property Parameters As List(Of DbParameter)
        Get
          Parameters = New List(Of DbParameter)
          Parameters.Add(Me.Date)
          Parameters.Add(Me.Thread)
          Parameters.Add(Me.Level)
          Parameters.Add(Me.Source)
          Parameters.Add(Me.Message)
          Parameters.Add(Me.Exception)
        End Get
      End Property
      Private ReadOnly Property [Date] As DbParameter
        Get
          Return New DbParameter("Date", New DbPatternLayout(PATTERN_DATE), DbType.Date, 0)
        End Get
      End Property
      Private ReadOnly Property Thread As DbParameter
        Get
          Return New DbParameter("Thread", New DbPatternLayout(PATTERN_THREAD), DbType.String, 255)
        End Get
      End Property
      Private ReadOnly Property Level As DbParameter
        Get
          Return New DbParameter("Level", New DbPatternLayout(PATTERN_LEVEL), DbType.String, 50)
        End Get
      End Property
      Private ReadOnly Property Source As DbParameter
        Get
          Return New DbParameter("Source", New DbPatternLayout(PATTERN_SOURCE), DbType.String, 255)
        End Get
      End Property
      Private ReadOnly Property Message As DbParameter
        Get
          Return New DbParameter("Message", New DbPatternLayout(PATTERN_MESSAGE), DbType.String, 4000)
        End Get
      End Property
      Private ReadOnly Property Exception As DbParameter
        Get
          Return New DbParameter("Exception", New DbExceptionLayout)
        End Get
      End Property
      Private Const PATTERN_MESSAGE As String = "%message"
      Private Const PATTERN_THREAD As String = "%thread"
      Private Const PATTERN_SOURCE As String = "%logger.%M()"
      Private Const PATTERN_LEVEL As String = "%level"
      Private Const PATTERN_DATE As String = "%date{yyyy-MM-dd HH:mm:ss.fff}"
      Private Const COMMAND_TEXT As String = "INSERT INTO Log ({0}) VALUES ({1})"
      '======================================================================================
      ' Available patterns:
      ' http://logging.apache.org/log4net/release/sdk/log4net.Layout.PatternLayout.html
      '======================================================================================
    End Class
