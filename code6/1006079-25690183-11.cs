    Public MustInherit Class claPageBaseForm
        Inherits System.Web.UI.Page
    
        Protected Sub New()
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(System.Globalization.CultureInfo.CurrentCulture.Name, False)
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(System.Globalization.CultureInfo.CurrentCulture.Name, False)
        End Sub
