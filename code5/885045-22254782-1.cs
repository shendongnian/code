    Public Function UserIsAdmin(ByVal userName As String) As Boolean
            Dim groupName As String = "administrators" '<--You can localize this'
            Dim isAdmin As Boolean
            Using context As PrincipalContext = New PrincipalContext(ContextType.Machine)
                Dim gfilter As GroupPrincipal = GroupPrincipal.FindByIdentity(context, groupName)
                If gfilter IsNot Nothing Then
                    Dim members = gfilter.GetMembers
                    For Each member In members
                        If String.Compare(member.Name, userName, True) = 0 Then
                            isAdmin = True
                        End If
                    Next
                End If
            End Using
            Return isAdmin
    End Function
