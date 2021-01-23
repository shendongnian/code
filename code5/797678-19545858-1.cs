    Public Class Navigation
        Inherits System.Web.UI.UserControl
    
        Public Property ShowWorkText As String
            Get
                Return LiteralShowWork.Text
            End Get
            Set(value As String)
                LiteralShowWork.Text = value
            End Set
        End Property
    
    End Class
