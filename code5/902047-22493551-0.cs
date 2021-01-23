    Dim i As Integer = 0
    Dim i2 As Integer
    Dim Colinx As Integer
    Do Until i = dt1.Columns.Count
    If dt1.Columns(i).ColumnName.Contains("OTS") Then
    Colinx = dt2.Columns.Count
    dt2.Columns.Add(dt1.Columns(i).ColumnName, GetType(Integer))
    
    i2 = 0
    Do Until i2 = dt2.Rows.Count
    dt2.Rows(i2)(Colinx) = dt1.Rows(i2)(i)
    i2 = i2 + 1
    Loop
    
    End If
    i = i + 1
    Loop
