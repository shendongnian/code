    var query = yourlist.Select(x=>{
             var arr = x.Split(new string[] { "-----" }, StringSplitOptions.None);
             return new{
                Name = arr[0],
                Value = Int32.Parse(arr[1])
             };
        })
        .GroupBy(x=>x.Name)
        .Select(x=> new{Name = x.Key, Value=x.Sum(y=>y.Value)});
