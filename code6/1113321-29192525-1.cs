    var dataModel = db.ChapterRepository.GetAll().ToList();
    var myResult = MapColumnsAndGetResult(dataModel, myColumns);
    foreach (var x in myResult)
            {
                foreach (var property in (IDictionary<String, Object>)x)
                {
                    Console.WriteLine(property.Key + ": " + property.Value);
                }
            }
