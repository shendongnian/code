                List<string> vals = new List<string>();
                vals.AddRange(filterValue.Split(new char[] { ',' }));
                var bindingEntities = entities.Where(
                             e => e.ExtraProperties.Any(
                             kvp => vals.Contains(kvp.Value.ToString())).ToList());
