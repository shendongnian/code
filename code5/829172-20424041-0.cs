    var groups = data.GroupBy(item => new { item.Class, item.Division });
                     .Select(item => new StudentCount 
                                         { 
                                             Class = item.Key.Class, 
                                             Division = item.Key.Divison,
                                             Count = item.Count()
                                         });
