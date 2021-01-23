    var resultList = new List<int>();
    File.ReadAllLines("filepath") 
        .ToList()
        .ForEach((line) => {
                                var numbers = line.Split()
                                                  .Select(c => (int)c);
                                resultList.AddRange(numbers); 
                            });
