    @using (Html.BeginForm("Index", "Home")) {
        @Html.DropDownListFor(x => x.SelectedClientId, new SelectList(Model.Clients, "PrimaryKey", "Name", Model.SelectedClientId), "--Select Client--", new { onchange = "this.form.submit();" });
    
        @Html.DropDownListFor(y => y.SelectedProjectId, new SelectList(Model.Projects, "PrimaryKey", "Name", Model.SelectedProjectId), "--Select Project--", new { onchange = "this.form.submit();" })
   
        @Html.DropDownListFor(z => z.SelectedFacilityId, new SelectList(Model.Facilities, "PrimaryKey", "Name", Model.SelectedFacilityId), "--Select Facility--", new { onchange = "this.form.submit();" })
    }
