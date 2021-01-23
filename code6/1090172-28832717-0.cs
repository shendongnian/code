    @model List<User>
    
    @using (Html.BeginForm("Index", "Home", FormMethod.Post))
        {
            <table>
                @for (int i = 0; i < Model.Count;i++ )
                { 
                    <tr>
                        <td>@Html.TextBox("users[" + @i + "].Email", Model[i].Email)</td>
                    </tr>
                }
             
            </table>
        }
