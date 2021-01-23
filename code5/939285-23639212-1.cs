    Imports System.ComponentModel
    Class MainWindow : Implements INotifyPropertyChanged
    Private _MyTabIndex As Integer
    Public Property MyTabIndex As Integer
        Get
            Return _MyTabIndex
        End Get
        Set(value As Integer)
            If value <> _MyTabIndex Then
                _MyTabIndex = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("MyTabIndex"))
            End If
        End Set
    End Property
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        MyTabIndex += 1
    End Sub
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = Me
    End Sub
    End Class
