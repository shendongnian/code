    <table class="table">
        @for(int i = 0; i < Model.Systemen.Count; i++)
        {
            <tr>
                <td>
                    @Html.HiddenFor(modelItem => Model.Systemen[i].Systeemnaam)
                    @Html.HiddenFor(modelItem => Model.Systemen[i].isSelected)
                    @Html.DisplayFor(modelItem => Model.Systemen[i].Systeemnaam)
                </td>
                <td>
                    @Html.CheckBoxFor(modelItem => Model.Systemen[i].isSelected)
                </td>
            </tr>
        }
    </table>
