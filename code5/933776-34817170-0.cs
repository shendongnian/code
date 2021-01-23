    Imports System.Runtime.CompilerServices
    Imports System.Windows.Forms
    
    Public Module DB_Extensions
        
        <Extension()> _
        Public Function LINQ_Filter(Of RowT As DataRow)(ByRef table As TypedTableBase(Of RowT), predicate As System.Func(Of RowT, Boolean)) As TypedTableBase(Of RowT)
            ' Create clone of table to not loose filtered data on original table and return a new table instead
            Dim ret As TypedTableBase(Of RowT) = table.Clone()
            ret.Clear()
            ' Using .ImportRow() method garantees to not loose original table schema after return
            For Each r As RowT In table.Where(predicate)
                ret.ImportRow(r)
            Next
            Return ret
        End Function
    
    End Module
