     command.CommandText = "select photo from mytable where id=1"
     Try
        Dim productImageByte As Byte() = TryCast(command.ExecuteScalar, Byte())
        If productImageByte IsNot Nothing Then
        Using productImageStream As Stream = New System.IO.MemoryStream(productImageByte)
            PPicBoxPhoto.Image = Image.FromStream(productImageStream)
        End Using
    	End If
    Catch
        Throw
    End Try
