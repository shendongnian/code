    <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditColumn">
                    </telerik:GridEditCommandColumn>
    
    Protected Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs)
    	If TypeOf e.Item Is GridDataItem Then
    		Dim item As GridDataItem = TryCast(e.Item, GridDataItem)
    
    		DirectCast(item("EditColumn").Controls(0), ImageButton).Attributes.Add("onclick", "alert('test')")
    	End If
    End Sub
