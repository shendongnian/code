	Private Sub TreeView1_DrawNode(sender As Object, e As DrawTreeNodeEventArgs) Handles trvIdent.DrawNode
		Dim treeView = e.Node.TreeView
		Dim selected = (e.Node Is treeView.SelectedNode)
		Dim unfocused = Not treeView.Focused
		Dim font = If(e.Node.NodeFont IsNot Nothing, e.Node.NodeFont, treeView.Font)
		Dim textSize = e.Graphics.MeasureString(e.Node.Text, font)
		Dim bounds = New Rectangle(e.Bounds.X, e.Bounds.Y,
								   Convert.ToInt32(textSize.Width),
								   Math.Max(Convert.ToInt32(textSize.Height), e.Bounds.Height))
		e.DrawDefault = False
		If selected Then
			e.Graphics.FillRectangle(SystemBrushes.Highlight, bounds)
			e.Graphics.DrawString(e.Node.Text, font, SystemBrushes.HighlightText, bounds.Location)
		Else
			e.Graphics.FillRectangle(SystemBrushes.Window, bounds)
			e.Graphics.DrawString(e.Node.Text, font, SystemBrushes.WindowText, bounds.Location)
		End If
		'e.Graphics.DrawRectangle(Pens.Magenta, bounds)
	End Sub
    
    
