    Public Class UserAccount    
        Public Property Employee_ID() As Integer
        Public Property Email_Address() As String
        Public Property Location_ID() As String
        Public Property Department_ID() As String
        Public Property Company_ID() As String
        Public Property Password_Expiry() As DateTime
        Public Property Win_User_Name() As String
        Public Property First_Name() As String
        Public Property Last_Name() As String
        Public Property Message_Number() As Integer
        Public Property Message_Text() As String
        Public Property Password() As String
    
        Public Overrides Function ToString() As String
            Dim serializer As JavaScriptSerializer = New JavaScriptSerializer
            Dim result As String = serializer.Serialize(Me)
            Return result
        End Function
    
        Public Function FromString(str As String) As UserAccount
            Dim serializer As JavaScriptSerializer = New JavaScriptSerializer
            Return serializer.Deserialize(Of UserAccount)(str)
        End Function
    
        Public Function GetUserInfo() As UserAccount 'Returns user info as a strongly typed object from what is saved in the cookie
            Dim user As UserAccount
            Dim cookie As HttpCookie = DirectCast(System.Web.HttpContext.Current.Request.Cookies(FormsAuthentication.FormsCookieName), HttpCookie)
            Dim ticket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(cookie.Value)
    
            user = Me.FromString(ticket.UserData)
    
            Return user
        End Function
    
        Public Shared Function Encrypt(password As String, Win_User_Name As String)
    
            Dim _password As New StringBuilder
            Try
    
               'encryption stuff happens here
            Catch er As Exception
                Return ""
            End Try
    
            Return _password.ToString
           
        End Function
    
    End Class
