    Public Sub CheckSession()
            With HttpContext.Current
                .Response.Cache.SetExpires(DateTime.UtcNow.AddSeconds(-1))
                .Response.Cache.SetCacheability(HttpCacheability.NoCache)
                .Response.Cache.SetNoStore()
                If .Session.IsNewSession = True Then LogOut()
                'there You can put some code checking is user logged, ...
            End With
        End Sub
    
        Public Sub LogOut()
            With HttpContext.Current
                .Session.RemoveAll()
                .Session.Clear()
                .Session.Abandon()
                Try
                    .Response.Cookies.Add(New System.Web.HttpCookie("ASP.NET_SessionId", ""))
                Catch ex As Exception
    
                End Try
                .Response.Redirect("Default.aspx")
            End With
        End Sub
