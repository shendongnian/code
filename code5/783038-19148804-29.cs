    Private Type tList
        Encapsulated As Collection
        ItemTypeName As String
    End Type
    Private this As tList
    Option Explicit
    
    Private Function IsReferenceType() As Boolean
        If this.Encapsulated.Count = 0 Then IsReferenceType = False: Exit Function
        IsReferenceType = IsObject(this.Encapsulated(1))
    End Function
    
    Public Property Get NewEnum() As IUnknown
        Attribute NewEnum.VB_Description = "Gets the enumerator from encapsulated collection."
        Attribute NewEnum.VB_UserMemId = -4
        Attribute NewEnum.VB_MemberFlags = "40"
        Set NewEnum = this.Encapsulated.[_NewEnum]
    End Property
    
    Private Sub Class_Initialize()
        Set this.Encapsulated = New Collection
    End Sub
    
    Private Sub Class_Terminate()
        Set this.Encapsulated = Nothing
    End Sub
