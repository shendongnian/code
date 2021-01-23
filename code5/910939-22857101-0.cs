     Imports System
     Imports System.IO
     Imports System.Text
    Public Class Form1
    Public Structure Kerdesek
        Public hanyadik As Integer
        Public kerdes As String
        Public valaszA As String
        Public valaszB As String
        Public valaszC As String
        Public valaszD As String
        Public helyesValasz As Char
    End Structure
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Private Sub BetöltésToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BetöltésToolStripMenuItem.Click
        OpenFile.ShowDialog()
    End Sub
    Private Sub OpenFile_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFile.FileOk
        Dim sr As StreamReader = New StreamReader(OpenFile.OpenFile())
        Dim firstLine As Boolean = True
        Dim row As Integer
        Dim lst As New List(Of Kerdesek)
        While Not (sr.EndOfStream)
            If (firstLine = True) Then
                row = sr.ReadLine()
                firstLine = False
            ElseIf (firstLine = False) Then
                For i = 1 To row
                    Dim ujKerdes As New Kerdesek
                    ujKerdes.hanyadik = sr.ReadLine()
                    ujKerdes.kerdes = sr.ReadLine()
                    ujKerdes.valaszA = sr.ReadLine()
                    ujKerdes.valaszB = sr.ReadLine()
                    ujKerdes.valaszC = sr.ReadLine()
                    ujKerdes.valaszD = sr.ReadLine()
                    ujKerdes.helyesValasz = sr.ReadLine()
                    lst.Add(ujKerdes)
                Next i
            End If
        End While
        sr.Close()
        For Each item As Kerdesek In lst
            LabelHanyadikKerdes.Text = item.hanyadik
            LabelKerdes.Text = item.kerdes
            LabelA.Text = item.valaszA
            LabelB.Text = item.valaszB
            LabelC.Text = item.valaszC
            LabelD.Text = item.valaszD
            MessageBox.Show(item.hanyadik)
            MessageBox.Show(item.kerdes)
        Next
    End Sub
    End Class
