    Partial Public Class Company
    
        Public ReadOnly Property visibleContracts As SortableBindingList(Of contract)
            Get
                Dim list = New SortableBindingList(Of contract)
    
                For Each c As contract In contracts.ToList
                    list.Add(c)
                Next
    
                Return list
            End Get
        End Property
    
    End Class
