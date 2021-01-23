     Public Function FindUserPrincipal(ByVal userName As String) As UserPrincipal
        Try
            Return UserPrincipal.FindByIdentity(New PrincipalContext(ContextType.Domain, "mydomain"), IdentityType.SamAccountName, userName)
        Catch ex As PrincipalOperationException
            Return Nothing
        End Try
    End Function
