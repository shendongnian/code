         If Session Is Nothing OrElse Session(Current_User) Is Nothing Then
                        udtGeneral = GetdoGeneralInstance()
                        susername = Request.ServerVariables("LOGON_USER").Split("\")(1).ToString()
    'Either of these work i believe                    
    susername = Request.ServerVariables(7).Split("\")(1).ToString()
                        'Dim susername1 = Request.Browser.Capabilities("extra").ToString.Split(";")(14).ToString.Split(":")(1).ToString
                        Session("ipAddress") = Request.ServerVariables("REMOTE_ADDR").ToString()
                    End If
