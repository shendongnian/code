    @for (int i = 0; i < Model.SecurityAccessList.Count; i++)
    {
      @Html.CheckBoxFor(m => m.SecurityAccessList[i].IsSelected)
      @Html.LabelFor(m => m.SecurityAccessList[i].IsSelected, Model.SecurityAccessList[i].Access_Name)
      @Html.HiddenFor(m => m.SecurityAccessList[i].ID)
    }
