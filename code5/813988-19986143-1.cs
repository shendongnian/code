    @{
        List<SelectListItem> selectList = new List<SelectListItem>();
        foreach(Item c in ViewBag.Items)
        {
            SelectListItem i = new SelectListItem();
            i.Text = c.Name.ToString();
            i.Value = c.SiteID.ToString();
            selectList.Add(new SelectListItem());
        }
    }
    @using (Html.BeginForm())
    {
        @Html.DropDownList("Casinos", new SelectList(selectList,"Value","Text"));
    }
