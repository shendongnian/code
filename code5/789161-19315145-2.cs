      using(Html.BeginForm("Index", "Home", FormMethod.Post, new { id = "parameterForm" }))
        {
        <div id="inputBoxesDIV">
             for(int i = 0; i < Model.GetParameters().Count; i++)
               { 
                    Html.TextBoxFor(m => m.GetParameters().ElementAt(i).Name, new { name = "name" + i, size = 20 })
                    Html.TextBoxFor(m => m.GetParameters().ElementAt(i).Value, new { name = "Value" + i, size = 60 })
            }
        </div>
        }
