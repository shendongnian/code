    /*The adjusted partial View*/
     @model MyViewModel
     ...
     <div>
         @for (int i = 0; i < Model.Ddls.Count; i++)
         {
            string hiddenClass = "";
            // The string hiddenClass will be "hidden" only for the Ddls marked as hidden from the ApplyRules method.
            if (ViewBag.HiddenIds.Contains(Model.Categories[i].Id))
            {
                hiddenClass = "hidden";   
            }
            // The objects are created even if are hidden
            @Html.DropDownListFor(m => m.Ddls[i].SelectedValue, new SelectList(Model.Ddls[i].Items, "Value", "Text", Model.Ddls[i].SelectedValue), new { @class = "some-classes " + hiddenClass})
            @Html.HiddenFor(m => m.Ddls[i].Id)
            @Html.HiddenFor(m => m.Ddls[i].Name)
          }
     </div>
     ...
     <input type="submit" value="Ajax call" id="trigger" class="hidden" />
