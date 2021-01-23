    Partial Public Class DlmsDataContext
    
        Public Shared Property ModelFileName As String = "AvrEntities" ' (AvrEntities.edmx)
    
        Public Sub New(ByVal avrConnectionString As String)
            MyBase.New(CStr(avrConnectionString.ToEntityConnectionString(ModelFileName, True)))
        End Sub
    
    End Class
