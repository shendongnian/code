    from t in db.Table
    group t by new 
              {
               Category = t.Category.Substring(0), 
               t.Question
              } into g
    orderby g.Key.Category
    select new 
    {
        CategoryName = g.Key.Category,
        Question = g.Key.Question,
        TotalCount = g.Count(),
        AnsLessEqual3 = g.Count(d => d.Answer <= 3),
        Ans5 = g.Count(d => d.Answer = 5),
        Ans789 = g.Count(d => d.Answer = 7 || d.Answer = 8 || d.Answer = 9)
     }
