    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
    Dim frmUser As New UserForm
    frmUser.TopLevel = False
    frmUser.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    
    Me.TabControl1.TabPages(0).Controls.Add(frmUser)
    frmUser.Show()
    
    End Sub
