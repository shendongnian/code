    @using (Html.BeginForm("Update", "ControllerName"))
    {
    	@Html.ValidationSummary()
    	@Html.LabelFor(u => u.FirstName)
    	@Html.TextBoxFor(u => u.FirstName)
    	{
    		Model.ActionMethod = ActionMethodEnum.Update;
    	}
    	@Html.HiddenFor(u => u.ActionMethod)
    
    	<button type="submit" id="btnUpdate">Update</button>
    }
    
    @using (Html.BeginForm("Change", "ControllerName"))
    {
    	@Html.ValidationSummary()
    	@Html.LabelFor(u => u.LastName)
    	@Html.TextBoxFor(u => u.LastName)
    	{
    		Model.ActionMethod = ActionMethodEnum.Change;
    	}
    	@Html.HiddenFor(u => u.ActionMethod)
    	
    	<button type="submit" id="btnChange">Change</button>
    }
