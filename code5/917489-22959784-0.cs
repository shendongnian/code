    foreach (var person in _db.People.OrderByDescending(p => p.LastUpdated))
            {
                data.Add(new List<string>
                {
                    person.UserId,
                    person.FullName,
                    person.Title,
                    (_db.AnotherTable.Where(p => p.personID == person.personID).FirstOrDefault() == null? "Y": "N")
                }    
            }
