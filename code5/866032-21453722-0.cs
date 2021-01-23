    IList<SelectListItem> CustomList = new List<SelectListItem>();
    foreach (var item in sizeInfo)
    {
     SelectListItem listItem = new SelectListItem();
     listItem.Value = item.yourattribue.ToString();
     listItem.Text = item._sizeOption;
     sizeList.Add(listItem);
    }
    ViewData["CustomList"] = CustomList;
