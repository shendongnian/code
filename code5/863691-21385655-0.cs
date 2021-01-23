        @for (int i = 0; i < Model.ModelData.Count; i++)
        {
            <li>
                @Html.HiddenFor(m => Model.ModelData[i].Id)
                @Html.CheckBoxFor(m => Model.ModelData[i].Checked)
            </li>
        }
