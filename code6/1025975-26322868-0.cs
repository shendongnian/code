    public static MvcHtmlString DatePickerDropDowns(this HtmlHelper html, string dayName, string monthName, string yearName)
    {
        var daysList = new TagBuilder("select");
        var monthsList = new TagBuilder("select");
        var yearsList = new TagBuilder("select");
        daysList.Attributes.Add("name", dayName);
        monthsList.Attributes.Add("name", monthName);
        yearsList.Attributes.Add("name", yearName);
        StringBuilder days = new StringBuilder();
        StringBuilder months = new StringBuilder();
        StringBuilder years = new StringBuilder();
        int beginYear = DateTime.UtcNow.Year - 100;
        int endYear = DateTime.UtcNow.Year;
        for (int i = 1; i <= 31; i++)
            days.AppendFormat("<option value='{0}'>{0}</option>", i);
        for (int i = 1; i <= 12; i++)
            months.AppendFormat("<option value='{0}'>{0}</option>", i);
        for (int i = beginYear; i <= endYear; i++)
            years.AppendFormat("<option value='{0}'>{0}</option>", i);
        daysList.InnerHtml = days.ToString();
        monthsList.InnerHtml = months.ToString();
        yearsList.InnerHtml = years.ToString();
        return MvcHtmlString.Create(String.Concat(daysList.ToString(), monthsList.ToString(), yearsList.ToString()));
    }
