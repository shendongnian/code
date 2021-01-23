    Sub BindList1()
        Dim a As New Dictionary(Of String, Int16)
        a.Add("sdsd", 1)
        a.Add("dfsd", 2)
        ddlList.DataSource = a
        ddlList.DataTextField = "key"
        ddlList.DataValueField = "value"
        ddlList.DataBind()
    End Sub
    Sub BindList2()
        If ddlList.SelectedValue = 1 Then
            Dim a As New Dictionary(Of String, Int16)
            a.Add("222", 1)
            a.Add("333", 2)
            ddlList2.DataSource = a
        Else
            Dim b As New Dictionary(Of String, Int16)
            b.Add("444", 1)
            b.Add("555", 2)
            ddlList2.DataSource = b
        End If
        ddlList2.DataBind()
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindList1()
            BindList2()
        End If
    End Sub
    Protected Sub ddlList_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlList.SelectedIndexChanged
        BindList2()
    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        Dim value = ddlList.SelectedValue + ddlList2.SelectedValue
    End Sub
