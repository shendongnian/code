    // model
    public class ContactSearchModel
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Adresa { get; set; }
        public string Mentiuni { get; set; }
    }
    // view
    @using Demo.Model.ContactSearchModel
    @using (Html.BeginForm())
    {
        <th>
            @Html.TextBoxFor(model => model.Nume)
        </th>
        <th>
            @Html.TextBoxFor(model => model.Prenume)
        </th>
        <th>
            @Html.TextBoxFor(model => model.Adresa)
        </th>
        <th>
            @Html.TextBoxFor(model => model.Mentiuni)
        </th>
        <th>
            <input type="submit" name="submitSearch" value="Search" class="btn btn-info"
                   onclick=" location.href='@Url.Action("Search", "Home")' " />
        </th>
