    Imports System.Reflection
    Public Module Extenders
    <System.Runtime.CompilerServices.Extension>
    Public Function ToDataTable(Of T)(collection As IEnumerable(Of T), tableName As String) As DataTable
        Dim tbl As DataTable = ToDataTable(collection)
        tbl.TableName = tableName
        Return tbl
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function ToDataTable(Of T)(collection As IEnumerable(Of T)) As DataTable
        Dim dt As New DataTable()
        Dim tt As Type = GetType(T)
        Dim pia As PropertyInfo() = tt.GetProperties()
        'Create the columns in the DataTable
        For Each pi As PropertyInfo In pia
            Dim a = 
    If(Nullable.GetUnderlyingType(pi.PropertyType), pi.PropertyType)
            dt.Columns.Add(pi.Name, If(Nullable.GetUnderlyingType(pi.PropertyType), pi.PropertyType))
        Next
        'Populate the table
        For Each item As T In collection
            Dim dr As DataRow = dt.NewRow()
            dr.BeginEdit()
            For Each pi As PropertyInfo In pia
                dr(pi.Name) = If(Nullable.GetUnderlyingType(pi.PropertyType) Is GetType(DateTime), DBNull.Value, pi.GetValue(item, Nothing))
            Next
            dr.EndEdit()
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    End Module
