    Public Class Form1
    
        Private dt As New DataTable
    
        Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    
            dt.Columns.Add("header1")
            dt.Columns.Add("header2")
            dt.Columns.Add("header3")
            dt.Columns.Add("header4")
    
            For i = 0 To 250000
                dt.Rows.Add({i, i, i, i})
            Next
    
        End Sub
    
        Private Sub DataTableConvBtn_Click(sender As System.Object, e As System.EventArgs) Handles DataTableConvBtn.Click
    
            Dim starttime = Now.ToString
            Dim objExcel = CreateObject("Excel.Application")
            objExcel.Visible = True
            Dim objWorkbook = objExcel.Workbooks.Add()
            Dim objWorksheet = objWorkbook.Worksheets(1)
    
            objWorksheet.Range("A1").CopyFromRecordset(ConvertToRecordset(dt))
    
            Dim endtime = Now.ToString
    
            MsgBox(starttime & vbCrLf & endtime)
    
    
    
        End Sub
    
        Public Shared Function ConvertToRecordset(ByVal inTable As DataTable) As ADODB.Recordset
    
            Dim result As ADODB.Recordset = New ADODB.Recordset()
            result.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            Dim resultFields As ADODB.Fields = result.Fields
            Dim inColumns As System.Data.DataColumnCollection = inTable.Columns
    
            For Each inColumn As DataColumn In inColumns
                resultFields.Append(inColumn.ColumnName, TranslateType(inColumn.DataType), inColumn.MaxLength, ADODB.FieldAttributeEnum.adFldIsNullable, Nothing)
            Next
    
            result.Open(System.Reflection.Missing.Value, System.Reflection.Missing.Value, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
    
            For Each dr As DataRow In inTable.Rows
                result.AddNew(System.Reflection.Missing.Value, System.Reflection.Missing.Value)
    
                For columnIndex As Integer = 0 To inColumns.Count - 1
                    resultFields(columnIndex).Value = dr(columnIndex)
                Next
            Next
    
            Return result
    
        End Function
    
        Shared Function TranslateType(ByVal columnType As Type) As ADODB.DataTypeEnum
    
            Select Case columnType.UnderlyingSystemType.ToString()
                Case "System.Boolean"
                    Return ADODB.DataTypeEnum.adBoolean
                Case "System.Byte"
                    Return ADODB.DataTypeEnum.adUnsignedTinyInt
                Case "System.Char"
                    Return ADODB.DataTypeEnum.adChar
                Case "System.DateTime"
                    Return ADODB.DataTypeEnum.adDate
                Case "System.Decimal"
                    Return ADODB.DataTypeEnum.adCurrency
                Case "System.Double"
                    Return ADODB.DataTypeEnum.adDouble
                Case "System.Int16"
                    Return ADODB.DataTypeEnum.adSmallInt
                Case "System.Int32"
                    Return ADODB.DataTypeEnum.adInteger
                Case "System.Int64"
                    Return ADODB.DataTypeEnum.adBigInt
                Case "System.SByte"
                    Return ADODB.DataTypeEnum.adTinyInt
                Case "System.Single"
                    Return ADODB.DataTypeEnum.adSingle
                Case "System.UInt16"
                    Return ADODB.DataTypeEnum.adUnsignedSmallInt
                Case "System.UInt32"
                    Return ADODB.DataTypeEnum.adUnsignedInt
                Case "System.UInt64"
                    Return ADODB.DataTypeEnum.adUnsignedBigInt
            End Select
    
            Return ADODB.DataTypeEnum.adVarChar
    
    
        End Function
    
    
    
        Private Sub DtToExcelBtn_Click(sender As System.Object, e As System.EventArgs) Handles DtToExcelBtn.Click
    
            Dim starttime = Now.ToString
            Dim objExcel = CreateObject("Excel.Application")
            Dim objWorkbook = objExcel.Workbooks.Add()
            Dim objWorksheet = objWorkbook.Worksheets(1)
    
            Dim i = 1
            Dim rownumber = 1
    
            objExcel.Visible = True
    
            Do While (i < dt.Rows.Count)
                Dim colNum As Integer = 0
                Do While (colNum < dt.Columns.Count)
                    objWorksheet.Cells((i + rownumber), (colNum + 1)) = dt.Rows(i)(colNum).ToString
                    colNum = (colNum + 1)
                Loop
                i = (i + 1)
            Loop
    
            Dim endtime = Now.ToString
            MsgBox(starttime & vbCrLf & endtime)
    
    
    
        End Sub
    End Class
