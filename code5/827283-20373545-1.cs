    @model VendorViewModel
    ...
    @if (Model.Customer != null)
    {
        // make title selection configurable
        @if (Model.Customer.TitleOptions != null)
        {
            @Html.DropDownListFor(m => m.Customer.Title, new SelectList(m.Customer.TitleOptions, "[Select title]"))
        }
        else
        {
            @Html.EditorFor(m => m.Customer.Title)   
        }
        ...
    }
