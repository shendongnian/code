    Dim dinfo As New System.IO.DirectoryInfo(Server.MapPath(String.Format("~/{0}/{1}/", USER_ID, department)))
    
    If Not dinfo.Exists Then
    	dinfo.Create()
    End If
    
    System.IO.File.WriteAllBytes(System.IO.Path.Combine(dinfo.FullName, fileName), fileBytes)
