    var result = list.Select(item => new {
                               Id = item.A.Id, 
                               Value = item.A.Value 
                             }).ToList().AddRange(list.Select(item => new {
                               Id = item.B.Id, 
                               Value = item.B.Value 
                             });
