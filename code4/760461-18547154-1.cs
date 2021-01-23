    @using (@Html.BeginForm())
    {
        <table>
            @for (int i = 0; i < Model.Tasks.Count; i++)
            {
                <tr>
                    <td>
                        @Html.CheckBoxFor(m => m.Tasks[i].IsDone, new { data_id=Model.Tasks[i].Id })
                    </td>
                    <td>
                        @Html.EditorFor(m => m.Tasks[i].Title)
                    </td>
                    <td>
                        @Html.ActionLink("Delete", "Delete", new { id = Model.Tasks[i].Id })
                    </td>
                </tr>
            }
        </table>
    }
