     @using (Html.BeginForm("Subscriptions", "Group", FormMethod.Post))
         {
           <div id="communitygroupsedit" class="list-unstyled">
              <p> @if (Model.Groups[x].AdminOnly)
                    {
                      string adminTest = (Model.Groups[x].AdminOnly && !Model.IsUserAdministrator) ? "disabled=\"disabled\"" : string.Empty;
                      string checktest = Model.Groups[x].IsMember ? "checked=\"checked\"" : string.Empty;
                      <input type="checkbox" @adminTest @checktest />
    
                      @Html.HiddenFor(m => m.Groups[x].IsMember)
                      @Html.HiddenFor(m => m.Groups[x].Name)
                      @Html.HiddenFor(m => m.Groups[x].AdminOnly)
                   }
                  else
                     {
                       @Html.CheckBoxFor(m => m.Groups[x].IsMember)
                    @Html.HiddenFor(m => m.Groups[x].Name)
                     @Html.HiddenFor(m => m.Groups[x].AdminOnly)
                  }
                  @Html.Raw(Model.Groups[x].Name + " - " + Model.Groups[x].Description)
                                                 </p>
                   }
                 </div>
                 if (Model.Groups.Count > 0)
               {
               @Html.SubmitButton("Update groups", false, new { @class = "btn btn-primary" });
               }
            }
