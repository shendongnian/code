    Public Class iqAPI
    Public Shared Function postRequest(ByVal url As String, ByVal toSerialize As String, strHeader As String) As DataTable
        Dim wHeader As WebHeaderCollection = New WebHeaderCollection
        wHeader.Clear()
        wHeader.Add(strHeader)
        Dim wReq As WebRequest = WebRequest.Create(url)
        Dim postData As String = JsonConvert.SerializeObject(toSerialize)
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        wReq.Headers = wHeader
        wReq.Method = "POST"
        wReq.ContentType = "application/x-www-form-urlencoded"
        wReq.ContentLength = byteArray.Length
    Dim dataStream As Stream = wReq.GetRequestStream()
    dataStream.Write(byteArray, 0, byteArray.Length)
    dataStream.Close()
    Dim wResp As WebResponse = wReq.GetResponse()
    MsgBox(CType(wResp, HttpWebResponse).StatusDescription)
    dataStream = wResp.GetResponseStream()
    Using reader As New StreamReader(dataStream)
        Dim respFromServer As String = reader.ReadToEnd()
        Dim dtCudaClient As DataTable = JsonConvert.DeserializeObject(Of DataTable)("[" & respFromServer & "]")
        MsgBox(dtCudaClient.Rows(0).ToString)
        iqSTAMP.gvCudaClients.DataSource = dtCudaClient
        reader.Close()
        dataStream.Close()
        wResp.Close()
        Return dtCudaClient
    End Using
    Return Nothing
    End Function
