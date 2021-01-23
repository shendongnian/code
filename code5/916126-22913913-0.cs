    return results.Select(i =>
                    {
                        var singleOrDefault = categories.SingleOrDefault(c => c.Id.Equals(i.result.CategoryId));
                        return new Model
                            {
                                Score = i.Score,
                                Date = i.InstanceResult.TestDate,
                                Category = singleOrDefault != null ? singleOrDefault.Name : null
                            };
                    });
