    var resultList = new List<int>();
    File.ReadAllLines("filepath") 
        .ToList()
        .ForEach((line) => {
                                var numbers = line.Split()
                                                  .Select(c => Convert.ToInt32(c));
                                resultList.AddRange(numbers); 
                            });
