      Protected Sub dlImages_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlImages.ItemDataBound
                If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
    
                    CType(e.Item.FindControl("ImageButton1"), ImageButton).ImageUrl = "ImageResize.aspx?ImageName=ScreenMasterImages/" & e.Item.DataItem("ImgName") & "&BoxSize=" & 300
                    CType(e.Item.FindControl("ImageButton1"), ImageButton).ToolTip = e.Item.DataItem("PageName")
                End If
            End Sub
