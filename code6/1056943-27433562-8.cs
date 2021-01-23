    @model {...}.TabControlViewModel
    <div class="tabs">
    <ul>
        @for (int i = 0; i < Model.Pages.Count; i++)
        {
          <li>
              @Html.ActionLink(Model.Pages[i].Title, "ShowPartial", new  { formId = Model.FormId, controlId = Model.Pages[i].Id})
              @{ Model.Pages[i].PrefixForPartialRender = Html.GetFullText(m => m.Pages[i]);}
          </li>
        }
    </ul>
    </div>
