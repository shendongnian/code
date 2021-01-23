    @for (int i = 0; i < Model.Clients.Count; i++)
    {
        if (i == 0 || i % 3 == 0)
        {
            <tr>
        }
        <td>
            <div id="dataListItem" >
                @Html.Hidden("ClientID", Model.Clients[i].ClientID)
                @Html.Label(Model.Clients[i].ClientName)
                <input type='checkbox' name="ClientItemCheckBox" id="ClientItemCheckBox" style="color: #428bca;" />
            </div>
        </td>
        if (i % 3 == 2 || i == Model.Clients.Count - 1)
        {
            </tr>
        }
    }
