    @using (Html.BeginForm("save", "meter", FormMethod.Post))
    {
    	@Html.AntiForgeryToken()
    	@Html.ValidationSummary(true)
    
    	@Html.HiddenFor(model => Model.Entity.Id)
    	@Html.HiddenFor(model => Model.Entity.DifferentialMeter.MeterId)
    	@Html.HiddenFor(model => Model.Entity.LinearMeter.MeterId)
    	@Html.HiddenFor(model => Model.Entity.GatheringMeter.MeterId)
    
    	... all your awesome controls go here ...
    }
