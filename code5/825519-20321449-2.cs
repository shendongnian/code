    Imports System.IO
    Dim path As var = String.Format("~/{0}/", USER_ID)
    Dim folder As var = Server.MapPath(path)
    If Not Directory.Exists(folder) Then
        Directory.CreateDirectory(folder)
    End If
    System.IO.File.WriteAllBytes(Path.Combine(Server.MapPath(path), fileName), fileBytes)
