    Public Class PageBase
        Inherits System.Web.UI.Page
        Public MyConnection As New SqlClient.SqlConnection( _
            ConfigurationManager.ConnectionStrings("MyConnection").ConnectionString)
        Public Function GetData2(ByVal Sql As String, _
             MyConnection As SqlClient.SqlConnection) As DataTable
    
            '...code...'
    
        End Function
    End Class
