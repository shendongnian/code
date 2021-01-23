    @{
        int[] months = Enumerable.Range(1, 12).ToArray();
        int curMonth = DateTime.Today.Month;
    }
    
    @Html.DropDownListFor(x => x.ExpirationMonth, months.Select(x => 
        new SelectListItem {
            Text = x.ToString(),
            Value = x.ToString(),
            Selected = (x == curMonth)
        }
    ))
