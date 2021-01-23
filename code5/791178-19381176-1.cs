    @using (Html.BeginForm("Test3","Form"))
    {
        @Html.RadioButtonFor(m => m.Submit, SubmitAction.ByItem, Model.Submit== SubmitAction.ByItem ? new { Checked = "checked" } : null)
        @Html.RadioButtonFor(m => m.Submit, SubmitAction.ByVendor, Model.Submit== SubmitAction.ByVendor ? new { Checked = "checked" } : null ) 
        @Html.RadioButtonFor(m => m.Submit, SubmitAction.ByMember, Model.Submit== SubmitAction.ByMember ? new { Checked = "checked" } : null ) 
    
        
        @Html.ValidationSummary();
        <input type="submit"/>
    }
