    @using (Html.BeginForm("MethodName", "ControllerName", FormMethod.Post))
    {
        @{ var listItems = new List<MVC_WebUI.Models.SelectedListItems> { 
                       new MVC_WebUI.Models.SelectedListItems { Text = "---Select---", Value = "0" }, 
                       new MVC_WebUI.Models.SelectedListItems { Text = "Answer 1", Value = "1" }, 
                       new MVC_WebUI.Models.SelectedListItems { Text = "Answer 2", Value = "2" }, 
                       new MVC_WebUI.Models.SelectedListItems { Text = "Answer 3", Value = "3" }, 
                       new MVC_WebUI.Models.SelectedListItems { Text = "Answer 4", Value = "4" }                        
                }; 
          }
     @Html.DropDownList("Answer", new SelectList(listItems, "Value", "Text"), new { onchange = "getAlldata()" }) 
            <input type="submit" value="Click" />
      
    }
