    ------- WebService code ---
    Imports System.Web
    Imports System.Web.Services
    Imports System.Web.Services.Protocols
    Imports System.Collections
    Imports System.Collections.Generic
    ' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    ' <System.Web.Script.Services.ScriptService()> _
    <WebService(Namespace:="http://tempuri.org/")> _
    <WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Public Class WebService1
        Inherits System.Web.Services.WebService
        <WebMethod()> _
        Public Function HelloWorld() As List(Of test)
            Dim lst As New List(Of test)
            For i As Int16 = 0 To 10
                lst.Add(New test With {.text = "text" & i, .val = "val" & i})
            Next
            Return lst
        End Function
    End Class
    Public Class test
        Property text As String 
        Property val As String 
    End Class
