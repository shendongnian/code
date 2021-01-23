    <table>
        <thead>
            <tr>
                @{
                    var locationNames = Model.SelectMany(n => n.Inventory).Select(n => n.Location.Name).Distinct().ToArray();
                    foreach (var locationName in locationNames)
                    {
                        <td>@locationName</td>
                    }
                }
            </tr>
        </thead>
        <tbody>
            @foreach(var product in Model)
            {
                <tr>
                    @foreach(var columnName in locationNames)
                    {
                        <td>@product.Inventory.Single(i => i.Location.Name == columnName).Quantity</td>
                    }
                </tr>
            }
        </tbody>
    </table>
