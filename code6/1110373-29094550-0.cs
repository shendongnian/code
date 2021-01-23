    <table>
        @for (int i = 0; i < Model.People.Count; i++)
        {
            <tr>
                @Html.HiddenFor(m => m.People[i].PersonID)
                @Html.HiddenFor(m => m.People[i].Name)
                @if (hasMoreThanOnePerson)
                {
                   <td>
                       @Html.CheckBoxFor(m => m.People[i].IsSelected)
                   </td>
               }
               else
               {
                   @Html.HiddenFor(m => m.People[i].IsSelected)
               }
               <td>
                  <input type="text" value="@Model.People[i].Name" />
               </td>
            </tr>
        }
    </table>
