    Imports System.Data.OleDb
    Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim connetionString As String
        Dim cnn As OleDbConnection
        connetionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=yourdatabasename.mdb;"
        cnn = New OleDbConnection(connetionString)
        Try
            cnn.Open()
            MsgBox("Connection Open ! ")
            cnn.Close()
        Catch ex As Exception
            MsgBox("Can not open connection ! ")
        End Try
    End Sub
    End Class
