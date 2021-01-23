    <table class="table">
        @for(int i = 0; i < Model.Systemen.Count; i++)
        {
            <tr>
                <td>
                    @Html.HiddenFor(modelItem => modelItem.Systemen[i].Systeemnaam)
                    @Html.DisplayFor(modelItem => modelItem.Systemen[i].Systeemnaam)
                </td>
                <td>
                    @Html.CheckBoxFor(modelItem => modelItem.Systemen[i].isSelected)
                </td>
            </tr>
        }
    </table>
