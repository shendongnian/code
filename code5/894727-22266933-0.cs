    Public Class XWizardPageDesigner
        Inherits PanelDesigner
        Public Overrides Function CanBeParentedTo(ByVal parentDesigner As IDesigner) As Boolean
            Return ((Not parentDesigner Is Nothing) AndAlso TypeOf parentDesigner.Component Is XWizardControl)
        End Function
    End Class
    <ToolboxItem(False), Designer(GetType(XWizardPageDesigner))> _
    Public Class XWizardPage
        Inherits DevExpress.XtraEditors.XtraPanel
        Implements IComparable(Of XWizardPage)
    End Class
