    Public Class TestPageViewModel
        Public Property Errors() As ObservableCollection(Of TestClass)
            Get
                Return m_Errors
            End Get
            Private Set(value As ObservableCollection(Of TestClass))
                m_Errors = value
            End Set
        End Property
        Private m_Errors As ObservableCollection(Of TestClass)
        Public Sub New()
            Errors = New ObservableCollection(Of TestClass)()
            Errors.Add(New TestClass() With {
                 .Category = "Globalization",
                 .Number = 75
            })
            Errors.Add(New TestClass() With {
                .Category = "Features",
                .Number = 2
            })
            Errors.Add(New TestClass() With {
                 .Category = "ContentTypes",
                 .Number = 12
            })
            Errors.Add(New TestClass() With {
             .Category = "Correctness",
                 .Number = 83
            })
            Errors.Add(New TestClass() With {
                 .Category = "Best Practices",
                 .Number = 29
            })
        End Sub
        Private m_selectedItem As Object = Nothing
        Public Property SelectedItem() As Object
            Get
                Return m_selectedItem
            End Get
            Set(value As Object)
                ' selected item has changed
                m_selectedItem = value
            End Set
        End Property
    End Class
