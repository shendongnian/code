    @model ItemVM
    @using(Html.BeinForm())
    {
      @Html.LabelFor(m => m.Name)
      @Html.TextBoxFor(m => m.Name)
      @Html.ValidationMessageFor(m => m.Name)
      for(int i = 0; i < Model.Purposes.Count;i++)
      {
        @Html.CheckBoxFor(m => m.Purposes[i].IsSelected)
        @Html.LabelFor(m => m.Purposes[i].IsSelected, Model.Purposes[i].Name)
        @Html.HiddenFor(m => m.Purposes[i].Id) // plus hidden input for name if you want to post that as well
      }
      <input type="submit" />
    }
