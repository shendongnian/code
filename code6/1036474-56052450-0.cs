    Public Function DownloadFileWithCookieContainerWebRequest(URL As String, FileName As String)
        Dim webReq As HttpWebRequest = HttpWebRequest.Create(URL)
        Try
            webReq.CookieContainer = New CookieContainer()
            webReq.Method = "GET"
            Using response As WebResponse = webReq.GetResponse()
                Using Stream As Stream = response.GetResponseStream()
                    Dim reader As StreamReader = New StreamReader(Stream)
                    Dim res As String = reader.ReadToEnd()
                    File.WriteAllText(FileName, res)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
