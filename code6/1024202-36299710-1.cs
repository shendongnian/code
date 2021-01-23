    Imports System.Data.OleDb
    Imports System.Data.OleDb.OleDbDataReader
    
    Public Class Form1
        Dim provider As String
        Dim dataFile As String
        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection
    
    
       
    
    
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            provider = "Provider =Microsoft.ACE.OLEDB.12.0;Data Source="
            dataFile = "C:\Users\ANNALIZA\Desktop\New folder (4)\JABOYY1.accdb"
            connString = provider & dataFile
            myConnection.ConnectionString = connString
            myConnection.Open()
    
    
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM [ADMIN] WHERE [userName] = '" & TextBox1.Text & "' AND [userPassword] = '" & TextBox2.Text & "'", myConnection)
            Dim userFound As Boolean = False
            Dim FirstName As String = ""
            Dim LastName As String = ""
            Dim dr As OleDbDataReader = cmd.ExecuteReader
    
    
    
    
            While dr.Read
                userFound = True
                FirstName = dr("FirstName").ToString
                LastName = dr("LastName").ToString
    
            End While
            If userFound = True Then
                Form2.Show()
                Form2.Label1.Text = "Welcome" & FirstName & " " & LastName
            ElseIf TextBox1.Text = "" And TextBox2.Text = "" Then
                MsgBox("No such username and password found! Input first before you click LOG IN!", MsgBoxStyle.Critical, "Warning")
                Me.Show()
    
    
    
            ElseIf MsgBox("Sorry username and password not found!LOGIN FAILED", MsgBoxStyle.Exclamation, "Invalid Log in") Then
                TextBox1.Text = ""
                TextBox2.Text = ""
                Me.Show()
    
            End If
    
    
    
    
        End Sub
