    @model ViewModelDynamicAttribute.ViewModels.ComplexViewModel
    
    @using (Html.BeginForm("Update", "Home"))
    {
    	@Html.ValidationSummary()
    	@Html.LabelFor(u => u.FirstNameViewModel.Value)
    	@Html.TextBoxFor(u => u.FirstNameViewModel.Value)
    
    	<button type="submit" id="btnUpdate">Update</button>
    }
    
    @using (Html.BeginForm("Change", "Home"))
    {
    	@Html.ValidationSummary()
    	@Html.LabelFor(u => u.LastNameViewModelNameViewModel.Value)
    	@Html.TextBoxFor(u => u.LastNameViewModelNameViewModel.Value)
    	
    	<button type="submit" id="btnChange">Change</button>
    }
