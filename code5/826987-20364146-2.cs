	@model MVCTest.Models.Test
	@using (Html.BeginForm("UpdateItems", "Home", FormMethod.Post)) {
	 
		@Html.HiddenFor(m=>m.Id)
		
		for (int i = 0; i < Model.Items.Count; i++)
		{
		   
			<div>
				@Html.HiddenFor(m=>m.Items[i].Id)
				@Html.CheckBoxFor(m=>m.Items[i].Selected, new {id = "checkbox_" + i} )
				@Html.DisplayFor(m=>m.Items[i].Description)
			</div>
		}
		<button type="submit" class="mfButton" value="SaveItemss">Save Changes</button>
	}
	
