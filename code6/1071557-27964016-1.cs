        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	 If Page.Request.Url.Query.Count() > 0 Then
		ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "func", "Calc()", True)
	End If
        End Sub
  
