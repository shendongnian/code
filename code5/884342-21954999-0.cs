    if (ModelState.IsValid)
                {
                    foreach (var item in list)
                    {
                        ...
                        db.SaveChanges();
                    }
                }
