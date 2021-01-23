    @model DateTime?
    @{
    String modelValue = "";
    if (Model.HasValue)
     {
        if (Model.Value != DateTime.MinValue)
        {
            modelValue = Model.Value.ToShortDateString();
        }
     }
    }
    @Html.TextBox("", modelValue, new { @class = "date-picker"})
