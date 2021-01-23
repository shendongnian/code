            var legalEntitiesCollectionByType = new Dictionary<string, ICollection<Organisation>>
            {
                {
                    "Institutional", organisations
                        .Where(x => x.Type == "Institutional")
                        .ToList()
                },
                {
                    "Retail", organisations
                        .Where(x => x.Type == "Retail")
                        .ToList()
                }
            };
