    Protected Sub SaveFile(ByVal url As String, ByVal localpath As String)
            Dim loRequest As System.Net.HttpWebRequest
            Dim loResponse As System.Net.HttpWebResponse
            Dim loResponseStream As System.IO.Stream
            Dim loFileStream As New System.IO.FileStream(localpath, System.IO.FileMode.Create, System.IO.FileAccess.Write)
            Dim laBytes(256) As Byte
            Dim liCount As Integer = 1
            Try
                loRequest = CType(System.Net.WebRequest.Create(url), System.Net.HttpWebRequest)
                loRequest.Credentials = System.Net.CredentialCache.DefaultCredentials
                'loRequest.Credentials = New System.Net.NetworkCredential("username", "password", "domain")
                loRequest.Timeout = 600000
                loRequest.Method = "GET"
                loResponse = CType(loRequest.GetResponse, System.Net.HttpWebResponse)
                loResponseStream = loResponse.GetResponseStream
                Do While liCount > 0
                    liCount = loResponseStream.Read(laBytes, 0, 256)
                    loFileStream.Write(laBytes, 0, liCount)
                Loop
                loFileStream.Flush()
                loFileStream.Close()
            Catch ex As Exception
            End Try
        End Sub
