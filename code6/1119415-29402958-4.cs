    Imports System.Web.Services
    Imports System.Web.Services.Protocols
    Imports System.ComponentModel
    Imports System.Collections.Generic
    Imports System.Data.SqlClient
    Imports System.Web.Script.Serialization
    Imports System.ServiceModel.Web
    
    
    ' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    <System.Web.Script.Services.ScriptService()> _
    <System.Web.Services.WebService(Namespace:="http://someurl/")> _
    <System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
    <ToolboxItem(False)> _
    Public Class Calendar
        Inherits System.Web.Services.WebService
    
        <WebMethod()> _
        Public Sub EventList()
            'Public Function EventList(ByVal startDate As String, ByVal endDate As String) As String
            ' List to hold events
            Me.Context.Response.ContentType = "application/json; charset=utf-8"
    
            Dim events As New List(Of CalendarDTO)
    
            Dim comm1 As SqlCommand
            Dim conn1 As SqlConnection
            Dim reader1 As SqlDataReader
            Dim connectionString1 As String = ConfigurationManager.ConnectionStrings("CalTest").ConnectionString
            conn1 = New SqlConnection(connectionString1)
            comm1 = New SqlCommand("SELECT [id],[title] ,[description],[startdate_event] ,[enddate_event] ,[allday] FROM [CalTest].[dbo].[event]", conn1)
            conn1.Open()
    
    
            reader1 = comm1.ExecuteReader()
            While reader1.Read()
    
                Dim value As CalendarDTO = New CalendarDTO()
    
                Dim newstartdate As DateTime = reader1("startdate_event").ToString()
                Dim newenddate As DateTime = reader1("enddate_event").ToString()
    
                value.id = reader1("id").ToString()
                value.title = reader1("title").ToString()
                value.start = newstartdate.ToString("s")
                value.end = newenddate.ToString("s")
                value.allDay = reader1("allday").ToString()
    
                events.Add(value)
            End While
    
            reader1.Close()
            conn1.Close()
    
    
            Dim jss As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim strJSON As String = jss.Serialize(events)
            Context.Response.Write(jss.Serialize(events))
    
        End Sub
    End Class
