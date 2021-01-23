     Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
             repeaterConversation.DataSource = source
                repeaterConversation.DataBind()
     End Sub
     Protected Sub repeaterConversation_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repeaterConversation.ItemDataBound
              Repeater_Posts.DataSource = source
                Repeater_Posts.DataBind()
       End Sub
