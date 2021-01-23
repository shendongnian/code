    var bunnies = db.Bunnies.Where(p => p.Color == "white")
                            .Select(x => new SelectListItem
                                             {
                                                Value = x.Id.ToString(),
                                                Text = x.Name,
                                             });
