    var data = one.Join(two,
                        a => a.Id,
                        b => b.Id,
                        (a, b) => new
                        {
                            Id = a.Id,
                            Name = string.IsNullOrEmpty(a.Name) ? b.Name : a.Name
                        }).ToArray();
