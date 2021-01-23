    @if (Model != null)
    {
        <h3>@Model.Exception.GetType().Name</h3>
        <pre>
            @Model.Exception.ToString()
        </pre>
        <p>
            thrown in @Model.ControllerName @Model.ActionName
        </p>
    }
