     var toUpdateItm = MC_CRM_T001A.ItemDetails.Where(X => X.CatNo == SelectedCRM_T001A.CatNo).ToList();
    foreach (var itm in toUpdateItm.ToList())
      {
        var item = MC_CRM_T001A.PartDetails.FirstOrDefault(X => X.cat_item_id == itm.id);
        if (item != null) { MC_CRM_T001A.PartDetails.Remove(item); }
        if (itm.CatNo == SelectedCRM_T001A.CatNo) { MC_CRM_T001A.ItemDetails.Remove(itm);
      }
