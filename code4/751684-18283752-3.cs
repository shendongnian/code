     Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
             repeaterConversation.DataSource = source
                repeaterConversation.DataBind()
     End Sub
         Protected Sub repeaterConversation_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repeaterConversation.ItemDataBound
             If (item.ItemType = ListItemType.Item Or item.ItemType = ListItemType.AlternatingItem) Then
             //here you can do calulations based on the data bound in the parent repeater
             //and also bind to controls and child repeaters
             Repeater_Posts = item.FindControl("rptPosts")
             Repeater_NewPostBtn = item.FindControl("btnNewPost")
             Repeater_Posts.DataSource = source
             Repeater_Posts.DataBind()
              End If
           End Sub
