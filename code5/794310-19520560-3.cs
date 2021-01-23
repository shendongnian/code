    @model System.Collections.Generic.IEnumerable<string>
    <select>
    @foreach(var item in Model)
    {
        <option>@item</option>
    }
    </select>
