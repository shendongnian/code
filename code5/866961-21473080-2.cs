    @model  Dictionary<Category, Dictionary<Category, List<Category>>>
    @foreach (var l1 in Model) {
        @Html.Label(l1.Key.Name)
        foreach (var l2 in l1.Value) {
        <br />
        @Html.Label("| --" + l2.Key.Name);
                                         foreach (var l3 in l2.Value) {
        <br />
       @Html.Label("|---|   ----") @Html.ActionLink(l3.Name, "AddEnquiry", "Assessment", new { @id = l2.Key.UID }, null);
                                         }
        }
        <br />
    }
