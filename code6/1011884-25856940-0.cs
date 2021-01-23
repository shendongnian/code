    Session.Clear()                                                                
    Session.Abandon()                                                              
    Session.RemoveAll()                                                            
    If Request.Cookies("ASP.NET_SessionId") IsNot Nothing Then                     
    	Response.Cookies("ASP.NET_SessionId").Value = ""                       
    	Response.Cookies("ASP.NET_SessionId").Expires = DateTime.Now.AddMonths(-20)
    End If                                                  
