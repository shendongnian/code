    for(int i = 0; i < Model.Weeks.Count; i++)
    {
      <tr>
        <tr>Week @i</td>
        for(int j = 0; j < Model.Weeks[i].Days[j].Count j++)
        {
          <td>
            @Html.CheckBoxFor(m => m.Weeks[i].Days[j].IsSelected)
          </td>
        }
      </tr>
    }
