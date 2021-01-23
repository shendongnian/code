    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="FtpDir">ftp://------@ftp.domainname.com/www/en/...</param>
    ''' <param name="ftpusername">FTP user name</param>
    ''' <param name="ftppassword">FTP user password</param>
    ''' <param name="fileExtensions">file extension e.g New String() {".txt", ".aspx", ".png"}, Nothing means list all files.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetListOfFilesinFTPdirectory(FtpDir As String, ftpusername As String, ftppassword As String, Optional fileExtensions As String() = Nothing) As List(Of String)
        Dim FTPReq As FtpWebRequest = DirectCast(WebRequest.Create(FtpDir), FtpWebRequest)
        FTPReq.Method = WebRequestMethods.Ftp.ListDirectoryDetails
        FTPReq.Credentials = New NetworkCredential(ftpusername, ftppassword)
        FTPReq.UseBinary = True
        FTPReq.KeepAlive = False
        Using response As FtpWebResponse = DirectCast(FTPReq.GetResponse(), FtpWebResponse)
            Using responseStream As Stream = response.GetResponseStream()
                Using reader As New StreamReader(responseStream)
                    Dim RawDirectoryListingData As String = reader.ReadToEnd()
                    'Debug.WriteLine(RawDirectoryListingData)
                    'Windows FTP Server Response Format
                    'DateCreated        IsDirectory   Size  FileName
                    '06-09-14  07:01PM                39778 MasterPage.master
                    '06-09-14  07:01PM                 2806 MasterPage.master.vb
                    '09-01-10  01:43PM                 1046 masterpagelink.txt
                    '12-29-10  06:16PM                75293 MasterPageTR.master
                    '12-29-10  06:16PM                10500 MasterPageTR.master.vb
                    '09-01-10  01:43PM                10725 meebotest.aspx
                    '01-17-13  03:54PM       <DIR>          mp4player
                    '11-30-11  12:40PM                17164 news.aspx
                    '11-30-11  12:40PM                 2342 news.aspx.vb
                    '12-14-10  10:17PM                12889 news.xml
                    '12-14-10  08:14PM                16379 news1.xml
                    Dim lines() As String = Split(RawDirectoryListingData, Environment.NewLine)
                    Dim FTPFileNames As New List(Of String)
                    For Each line As String In lines
                        If String.IsNullOrEmpty(line) Then Continue For
                        Try
                            ''Parse date
                            'Dim DateCreatedStr As String = line.Substring(0, 17)
                            'Dim DateCreated As DateTime = Nothing
                            'DateTime.TryParse(DateCreatedStr, DateCreated)
                            line = line.Remove(0, 24)
                            ' Parse <DIR>
                            Dim dirStr As String = line.Substring(0, 5)
                            Dim isDirectory As Boolean = dirStr.Equals("<dir>", StringComparison.InvariantCultureIgnoreCase)
                            line = line.Remove(0, 5)
                            line = line.Remove(0, 10)
                            ' Parse name
                            Dim fName As String = line
                            If String.IsNullOrEmpty(fName) Then Continue For
                            If Not isDirectory Then
                                If fileExtensions Is Nothing OrElse fileExtensions.Length < 1 Then
                                    FTPFileNames.Add(fName)
                                Else
                                    For Each ext As String In fileExtensions
                                        Dim fExt As String = IO.Path.GetExtension(fName)
                                        If fExt.Equals(ext, StringComparison.InvariantCultureIgnoreCase) Then
                                            FTPFileNames.Add(fName)
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Catch ex As Exception
                            Continue For
                        End Try
                    Next
                    Return FTPFileNames
                End Using
            End Using
        End Using
        Return Nothing
    End Function
