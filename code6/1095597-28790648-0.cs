    var inventoryList = new List<dynamic>();
    for (int i = 0; i < 5; i++)
    {
        dynamic obj = new System.Dynamic.ExpandoObject();
        obj.Id = string.Format("P10{0}", i);
        obj.Name = string.Format("{0} Testing", i);
        inventoryList.Add(obj);
    }
    return View(inventoryList);
