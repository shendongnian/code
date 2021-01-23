       Public Shared Function ListToDataTable(ByVal _List As Object) As DataTable
        Dim dt As New DataTable
        If _List.Count = 0 Then
            MsgBox("The list cannot be empty. This is a requirement of the ListToDataTable function.")
            Return dt
        End If
        Dim obj As Object = _List(0)
        dt = ObjectToDataTable(obj)
        Dim dr As DataRow = dt.NewRow
        For Each obj In _List
            dr = dt.NewRow
            For Each p as PropertyInfo In obj.GetType.GetProperties
                dr.Item(p.Name) = p.GetValue(obj, p.GetIndexParameters)
            Next
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Shared Function ObjectToDataTable(ByVal o As Object) As DataTable
        Dim dt As New DataTable
        Dim properties As List(Of PropertyInfo) = o.GetType.GetProperties.ToList()
        For Each prop As PropertyInfo In properties
            dt.Columns.Add(prop.Name, prop.PropertyType)
        Next
        dt.TableName = o.GetType.Name
        Return dt
    End Function
