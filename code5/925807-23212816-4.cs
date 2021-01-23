    @model MVC3Stack.Models.ModelToSubmit
    @using (Html.BeginForm("Index"))
    {
        <table>
        Html.EditorFor(Model.Items);
        </table>
        <table>
        Html.EditorFor(Model.TransItems);
        </table>
        <input type="submit"/>
    }
