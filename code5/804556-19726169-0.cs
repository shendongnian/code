     info.AddRange(item.Where(i => i.Name.Contains("Test"))
                        .Select(i => {
                        new info
                            (
                                (string)data.Id.ToString(),
                                (string)data.Name,
                                (string)"",
                                (string)data.PhotoUrl,
                                (string)data.Description
                            )}));
