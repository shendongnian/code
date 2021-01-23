    var distinctIds = list.Distinct(item => item.CategoryId).ToList();
    var newList = new List<Member>();
    foreach(var id in distinctIds){
          newList.Add(list.Where(item => item.CategoryId == id).Min(item => item.Distance))
    }
    newList.OrderBy(item => item.CategoryId);
