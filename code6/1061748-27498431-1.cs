    Imports System.Data.Odbc
    Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim connetionString As String
        Dim cnn As OdbcConnection
        connetionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=yourdatabasename.mdb;"
        cnn = New OdbcConnection(connetionString)
        Try
            cnn.Open()
            MsgBox("Connection Open ! ")
            cnn.Close()
        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        End Try
    End Sub
    End Class
