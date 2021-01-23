    Imports log4net
    Imports log4net.Core
    Imports log4net.Layout
    Imports log4net.Appender
    Imports log4net.Repository.Hierarchy
    Public Class DbParameter
      Inherits AdoNetAppenderParameter
      Private ReadOnly Name As String
      Public Sub New(Name As String, Layout As DbExceptionLayout)
        Me.New(Name, Layout, DbType.String, 2000)
      End Sub
      Public Sub New(Name As String, Layout As ILayout, Type As DbType, Size As Integer)
        With New RawLayoutConverter
          Me.Layout = .ConvertFrom(Layout)
        End With
        Me.Name = Name.Replace("@", String.Empty)
        Me.ParameterName = "@{0}".ToFormat(Me.Name)
        Me.DbType = Type
        Me.Size = Size
      End Sub
      Public ReadOnly Property DbColumn As String
        Get
          Return "[{0}]".ToFormat(Me.Name)
        End Get
      End Property
    End Class
