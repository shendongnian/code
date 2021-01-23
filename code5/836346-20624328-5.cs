    @model  Demo.Models.SpeakerViewModel
    
    @using (Html.BeginForm())
    {
        <table>
            @for (int i = 0; i < Model.Speakers.Count; i++)
            {
            <tr>
                <td>@Html.EditorFor(m => m.Speakers[i].Name)</td>
    
                <td>@Html.EditorFor(m => m.Speakers[i].Email)</td>
            </tr>
            }
        </table>
        <input type="submit" value="Submit"/>
    }
