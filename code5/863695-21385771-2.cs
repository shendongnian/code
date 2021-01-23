    @model MVC.Controllers.TestViewModel
    
    @using (Html.BeginForm("TestAction", "Home"))
    {
        <ol>
            @for (int i = 0; i < Model.ModelData.Count() ; i++ )
            {
                <li>
                    @Html.HiddenFor(m => m.ModelData[i].Id)
                    @Html.CheckBoxFor(m => m.ModelData[i].Checked)
                </li>
            }
        </ol>
    
        <input type="submit" />
    }
