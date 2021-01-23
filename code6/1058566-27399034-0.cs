    Imports System
    Imports System.Web
    Imports System.Web.Services
    Partial Class _Default
        Inherits System.Web.UI.Page
        <WebMethod()> _
        Public Shared Function isDuplicate() As String
            Return "Hello text"
        End Function
    End Class
