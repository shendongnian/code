    for (int i = 0; i < Model.Adjustments.Count; i++)
    {
      var name = string.Format("Adjustments[{0}].Index", i);
      @Html.HiddenFor(m => m[i].ID)
      ....
      <input type=hidden name="@name" value="@i" />
    }
