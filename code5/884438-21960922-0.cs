    Public Shared Function ReadImageAES(ByVal FileName As String) As Image
        Dim img As Image = Nothing
        Try
            Using fs As New FileStream(FileName, FileMode.Open)
                Using cs As New CryptoStream(fs, Crypto.AES.CreateDecryptor, CryptoStreamMode.Read)
                    img = Image.FromStream(cs)
                End Using
            End Using
        Catch ex As Exception
            img = Nothing
            'Debug.Print("ReadImageAES()failed: " & ex.ToString)
        End Try
        Return img
    End Function
    Public Shared Sub WriteImageAES(ByVal FileName As String, ByVal img As Image, Optional ByVal NewUserKey As String = Nothing)
        If Not IsNothing(img) Then
            Try
                If File.Exists(FileName) Then
                    File.Delete(FileName)
                End If
                Using fs As New FileStream(FileName, FileMode.OpenOrCreate)
                    Dim Key() As Byte
                    If IsNothing(NewUserKey) Then
                        Key = Crypto.AES.Key
                    Else
                        Key = Crypto.SHA256Hash(NewUserKey)
                    End If
                    Using cs As New CryptoStream(fs, Crypto.AES.CreateEncryptor(Key, Crypto.AES.IV), CryptoStreamMode.Write)
                        Dim bmp As New Bitmap(img)
                        bmp.Save(cs, System.Drawing.Imaging.ImageFormat.Jpeg)
                        bmp.Dispose()
                        cs.FlushFinalBlock()
                    End Using
                End Using
            Catch ex As Exception
                'Debug.Print("WriteImageAES() Failed: " & ex.ToString)
            End Try
        Else
            MessageBox.Show(FileName, "GetImage() Failed")
        End If
    End Sub
