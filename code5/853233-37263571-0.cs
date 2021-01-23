       Private Sub Button1_Click(sender As System.Object, e As    Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles Button1.Click
        Dim Dirdata As String = "\\drive\folder\Template.xlsb"
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkbook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorksheet  as Microsoft.Office.Interop.Excel.Worksheet
        xlApp = New Microsoft.Office.Interop.Excel.Application()
        xlWorkbook = xlApp.Workbooks.Open(Dirdata, , True, , "password")
        xlApp.Visible = True
        xlWorksheet = xlWorkbook.Worksheets(1)
        xlWorksheet.Activate()
        MsgBox(xlWorkbook.Name)
        xlWorkbook.Close(False)
    End Sub
