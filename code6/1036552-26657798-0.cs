    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        NoSaleDropDown.Items.Add(New ListItem("one", 1))
        NoSaleDropDown.Items.Add(New ListItem("two", 2))
        NoSaleDropDown.Items.Add(New ListItem("three", 3))
    End Sub
    Public NoSaleReasonId As Integer = 2
    Protected Sub NoSaleDropDown_Load(sender As Object, e As EventArgs) Handles NoSaleDropDown.Load
        NoSaleDropDown.SelectedValue= NoSaleReasonId
    End Sub
