    @ Page Language="VB" debug="true" %>
    <%@ Import Namespace = "System.Data" %>
    <%@ Import Namespace = "MySql.Data.MySqlClient" %>
    <script language="VB" runat="server">
    Sub Page_Load(sender As Object, e As EventArgs)
        Dim username As String = Convert.ToString(User.Identity.Name.Substring(User.Identity.Name.IndexOf("\") + 1))
        Dim myConnection  As MySqlConnection
        Dim myDataAdapter As MySqlDataAdapter
        Dim myDataSet     As DataSet
        Dim strSQL As String
        Dim iRecordCount  As Integer
     
            myConnection = New MySqlConnection("server=localhost; user id=Directory_Admin; password=IMCisgreat2014; database=imc_directory_tool; pooling=false;")
    
            strSQL = "SELECT username FROM tbl_staff WHERE username = '" & username & "'"
                  
        myDataAdapter = New MySqlDataAdapter(strSQL, myConnection)
        myDataSet = New Dataset()
        myDataAdapter.Fill(myDataSet, "tbl_staff")
    
        MySQLDataGrid.DataSource = myDataSet
        MySQLDataGrid.DataBind()
    
    End Sub
    
    </script>
    
    <html>
    <head>
    <title>Simple MySQL Database Query</title>
    </head>
    <body>
        
    <form runat="server">
    
    <asp:DataGrid id="MySQLDataGrid" runat="server" />
    
    </form>
    
    </body>
    </html> 
