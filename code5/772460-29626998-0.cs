                {
                    "Institutional", organisations
                        .Where(x => x.Type == "Institutional")
                        .ToList()
                        .Select(o => new Organisation{Code = x.Code,Departaments = x.Departaments.OrderBy(c => c).ToList()  }).ToList()
                }
            }`
