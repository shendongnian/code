    @model IEnumerable<Klimatogrammen.ViewModels.VraagViewModel>
    @{
        Layout = null;
    }
    
    <script src="@Url.Content("~/Scripts/jquery.validate.min.js")"></script>
    <script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")"></script>
    @using (Html.BeginForm("Vraag", "Vraag"))
    {
        @Html.ValidationSummary(true)
        <table class="table">
            <tr>
            <th>
                @Html.DisplayNameFor(model => model.Vraag)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Antwoorden)
            </th>
    
            @foreach (var item in Model)
            {
                <tr>
                    <td>
                        @Html.DisplayFor(modelItem => item.Vraag)
                    </td>
                    <td>
    
                        @Html.DropDownListFor(p => item.Antwoord, item.test, "--- Kies een antwoord ---")
                        @Html.ValidationMessageFor(m => item.Antwoord)
    
                    </td>
                </tr>
            }
        </table>
    
        <div style="text-align:center;"><input type="submit" value="Controleer uw vragen" class="btn btn-default" /></div>
    }
