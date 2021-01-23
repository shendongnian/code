    @model ContractWeb.Controllers.Grid
    @using(Html.BeginForm())
    {
        for(int i = 0; i < Model.Rows.Count; i++)
        {
            <div>
                @for(int j = 0; j < Model.Rows[i].Columns.Count; j++)
                {
                    @Html.TextBoxFor(m => m.Rows[i].Columns[j].Value)
                    @Html.ValidationMessageFor(m => m.Rows[i].Columns[j].Value)
                }
            </div>
        }
        <input type="submit" />
    }
