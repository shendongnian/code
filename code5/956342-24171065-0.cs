     <div class="editor-field">
            @{
                List<SelectListItem> items = new List<SelectListItem>();
                    //You may want to loop to generate your items.                 
                    items.Add(new SelectListItem
                    {
                        //Or you code that generates your SelectListItems
                        Text = "Your_Text_1", 
                        Value = "Your Value_1",
                    });
                items.Add(new SelectListItem
                    {
                        //Or you code that generates your SelectListItems
                        Text = "Your_Text_2", 
                        Value = "Your_Value_2",
                    });
            }
            @Html.DropDownListFor(model => model.PlayerA, items)           
            @Html.ValidationMessageFor(model => model.PlayerA)
