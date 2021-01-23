    <table>
       @for (int i = 0; i <= Model.Count; i++)
       {
           Html.EditorFor(m => Model[i].CarType, "CarTypeTemplate");
           Html.EditorFor(m => Model[i].CarModel, "CarModelTemplate");
       }
    </table>
