    @model PersonViewModel
    ...
    @using (Html.BeginForm())
    {
        <div>
            <table>
                <tbody>
                    @for (int i = 0; i < Model.Names.Count; i++)
                    {
                        <tr>
                            <td>
                                @Html.EditorFor(m => m.Names[i].FirstName)
                                @Html.ValidationMessageFor(m => m.Names[i].FirstName)
                            </td>
                            <td>
                                @Html.EditorFor(m => m.Names[i].MiddleName)
                                @Html.ValidationMessageFor(m => m.Names[i].MiddleName)
                            </td>
                            <td>
                                @Html.EditorFor(m => m.Names[i].LastName)
                                @Html.ValidationMessageFor(m => m.Names[i].LastName)
                            </td>
                            <td>
                                @Html.HiddenFor(m => m.Names[i].Id)
                                @Html.RadioButtonFor(m => m.Primary, Model.Names[i].Id, new { id = "Primary_" + i })
                            </td>
                        </tr>
                    }
                </tbody>
            </table>
        </div>
        <div>
            @Html.ValidationMessageFor(m => m.Primary)
        </div>
        <div>
            <input type="submit" value="Save" />
        </div>
    }
