    Private Sub myRepeater_ItemDataBound(sender as object, e as RepeaterItemEventArgs) andles myRepeater.ItemDataBound  
         If (e.Item IsNot Nothing AndAlso (e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem)) Then
             ' DO STUFF HERE
             Dim productPrice As HtmlInputHidden = (HtmlInputHidden).item.FindControl("hfPrice")
             Dim price As String = productPrice.Value
         End If 
    End Sub
