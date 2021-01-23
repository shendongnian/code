    @model IEnumerable<MvcMedicalStore.Models.MedicalProductViewModel>
    @{
        ViewBag.Title = "Edit";
    }
    <h2>Edit</h2>
    @using (Html.BeginForm()) {
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(true)
    
        <fieldset>
            <legend>MedicalProduct</legend>
            @Html.EditorFor(m => m)
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
    }
    <div>
        @Html.ActionLink("Back to List", "Index")
    </div>
    @section Scripts {
        @Scripts.Render("~/bundles/jqueryval")
    }
