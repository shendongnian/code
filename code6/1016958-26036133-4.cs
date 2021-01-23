    @for(var i = 0; i < Model.Animals.Count; i++)
    {
    
    	<dt>
    		@Html.HiddenFor(m => Model.Animals[i].ID)
    		@Html.HiddenFor(m => Model.Animals[i].Name)
    		@Html.CheckBoxFor(m = Model.Animals[i].Checked)
    	</dt>
    	<dd>
    		@Model[i].Name
    	</dd>
    	
    }
