            foreach (var entry in hierarchy)
            {
                foreach (var type in entry.Value)
                {
                    var meta = model.Add(type, false);
                    var members = getMemberNames(type);
                    log("adding members {0} to type {1}",
                        string.Join(",", members), type.Name);
                    meta.Add(getMemberNames(type));
                }
            }
