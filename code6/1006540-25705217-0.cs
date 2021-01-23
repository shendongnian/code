    <table id="myTable">
         @{
                int c = 0;
                for(int i = 0; i < Model.Count; i++)
                {
                    c++;
                    <tr class="@("block"+c)">
                        <td>
                            @Html.CheckBox("name", new {data_block=c})
                        </td>
                        <td>
                            @Html.EditorFor(m => item.Toolbox)
                        </td>
                        <td>
                            @Html.EditorFor(m => item.Name)
                        </td>
                        <td>
                            @Html.EditorFor(m => item.Link)
                        </td>
                    </tr>
                }
    </table>
