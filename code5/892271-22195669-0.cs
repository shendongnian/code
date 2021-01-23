    var choices = (from r in db.Reviews
                        where r.score <= averagescore
                        select r).ToList;
        foreach (var item in choices)
                {
                 var suggestion = new Suggestion()
                                {
                                 id = item.id,
                                 Userid = item.UserId,
                                 restaurantid = item.Restaurantid
                                 };
                                 db.Suggestions.Add(suggestion);
                                 db.SaveChanges();
                }
