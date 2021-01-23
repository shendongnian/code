      <System.Security.Permissions.PermissionSetAttribute( _
            System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Public Class UnDoControlCollectionUIEditor
        Inherits ControlCollectionUIEditor
        Public Sub New()
            MyBase.bExcludeForm = True
            MyBase.bExcludeSelf = True
           ' create a list of supported control TYPES
            typeList.Add(GetType(TextBox))
            '... 9 more lines adding control types to List(of System.Type)
        End Sub
     End Class
