    @for (int i = 0; i < Model.AsignedRoles.Count(); i++)
    {
             <div class="editor-field">
               @Html.LabelFor(model => model.AssignedRoles[i].IsAssigned)
               @Html.CheckBoxFor(model => model.AssignedRoles[i].IsAssigned)
               @Html.HiddenFor(model => model.AssignedRoles[i].RoleName)
             </div>
    }
