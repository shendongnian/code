    private List<SelectListItem> GetListOfObjectTypes(SelectList selectList, string objectTypeName, string objectTypeId)
    {
        List<SelectListItem> items = new List<SelectListItem>();
        foreach (METAObjectType item in selectList.Items)
        {
             bool isSelected = false;
             if (item.Name == objectTypeName)
             {
                    isSelected = true;
             }
             items.Add(new SelectListItem {Selected= isSelected, Text=item.Name, Value=item.ObjectTypeId.ToString()});
            }
            return items;
        }
