    Partial Public Class LoginUserControl
        Inherits System.Web.UI.UserControl
        Implements IView
        Public Shadows Event Load As EventHandler Implements IView.Load
        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    
        End Sub
    
    End Class
    
    
    Public Interface IView
        Event Load As EventHandler
    End Interface
