     var groups = data.GroupBy(item => new { item.Class, item.Division })
                      .Select(item => new StudentCount()
                      {
                          Class = item.Key.Class,
                          Division = item.Key.Division,
                          Count = item.Count().ToString() //the Count is of type string, so don't forget to make the proper conversion
                      });
