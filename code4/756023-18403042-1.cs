    var itemsToChange = objFreecusatomization.AllCustomizationButtonList
         .Where(p => p.CategoryID == btnObj.CategoryID
                     && p.IsSelected
                     && p.ID == btnObj.ID);
    foreach (var item in itemsToChange)
    {
        item.BtnColor = Color.Red.ToString();
        item.OtherColor = Color.Blue.ToString();
    }
