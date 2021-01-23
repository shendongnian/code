    Imports System.ComponentModel
    
    Public Class SomeClass
        Implements INotifyPropertyChanged
    
        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) _
            Implements INotifyPropertyChanged.PropertyChanged
    
        Protected Sub OnPropertyChanged(ByVal propName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
        End Sub
    
        Private _someProperty As String = ""
        Public Property SomeProperty As String
            Get
                Return _someProperty
            End Get
            Set(value As String)
                _someProperty = value
                OnPropertyChanged("SomeProperty")
            End Set
        End Property
    End Class
