    @model System.Collections.Generic.List<Entity>
    @foreach (var entity in Model)
    {
         @Html.RenderPartial("_mypartialview", entity)
    }
