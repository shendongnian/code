    ' User Is Admin?
    '
    ' Instructions:
    ' 1. Add a reference to 'System.DirectoryServices.AccountManagement'.
    ' 2. Imports System.DirectoryServices.AccountManagement
    '
    ' Example Usages:
    ' MsgBox(UserIsAdmin("Administrador"))
    ' MsgBox(UserIsAdmin(New Security.Principal.SecurityIdentifier("S-1-5-21-250596608-219436059-1115792336-500")))
    '
    ''' <summary>
    ''' Determines whether an User is an Administrator, in the current machine.
    ''' </summary>
    ''' <param name="UserName">Indicates the account Username.</param>
    ''' <returns><c>true</c> if user is an Administrator, <c>false</c> otherwise.</returns>
    Public Function UserIsAdmin(ByVal UserName As String) As Boolean
        Dim AdminGroupSID As New SecurityIdentifier("S-1-5-32-544")
        Dim pContext As New PrincipalContext(ContextType.Machine)
        Dim pUser As New UserPrincipal(pContext)
        Dim pSearcher As New PrincipalSearcher(pUser)
        Dim User As Principal =
            (From u As Principal In pSearcher.FindAll
            Where u.Name.Equals(UserName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault
        If User Is Nothing Then
            Throw New Exception(String.Format("User with name '{0}' not found.", UserName))
        End If
        Dim IsAdmin As Boolean =
            (From Group As GroupPrincipal In User.GetGroups
             Where Group.Sid = AdminGroupSID).Any
        pContext.Dispose()
        pSearcher.Dispose()
        pUser.Dispose()
        Return IsAdmin
    End Function
