    Option Strict On
    Option Explicit On
    Option Infer Off
    Public Class Form1
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn)
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn)
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn)
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn)
            For i As Integer = 0 To 100 Step 4
                Dim row As New DataGridViewRow
                Dim cell1 As New DataGridViewTextBoxCell
                Dim cell2 As New DataGridViewTextBoxCell
                Dim cell3 As New DataGridViewTextBoxCell
                Dim cell4 As New DataGridViewTextBoxCell
                cell1.Value = i.ToString
                cell2.Value = (i + 1).ToString
                cell3.Value = (i + 2).ToString
                cell4.Value = (i + 3).ToString
                row.Cells.AddRange({cell1, cell2, cell3, cell4})
                DataGridView1.Rows.Add(row)
            Next
        End Sub
    End Class
