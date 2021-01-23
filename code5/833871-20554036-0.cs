    Imports Excel = Microsoft.Office.Interop.Excel
    
    Public Class Form1   
        Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) _ 
        Handles Button1.Click
            Dim oExcel As New Excel.Application
    
            oExcel.Visible = True
    
            oExcel.Workbooks.Open("C:\book1.xls", False, True)
            oExcel.DisplayAlerts = False
    
            For Each wsheet As Excel.Worksheet In oExcel.ActiveWorkbook.Worksheets
                If wsheet.Name = "Sheet1" Then
                    wsheet.Activate()
                    wsheet.Range("A1").Select()
                    oExcel.ActiveWindow.FreezePanes = True
                    Exit For
                End If
            Next
        End Sub
    End Class
