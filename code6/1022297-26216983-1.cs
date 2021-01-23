    var y = from up1 in session.Query<Employment>()
            group up1 by up1.Name into g
            select new { Name = g.Key, UserId = g.Min(x => x.Company.Id) } into f
            join up2 in session.Query<Employment>() on new { f.Name, f.UserId } equals new { up2.Name, UserId = up2.Company.Id }
            select new SomeDto
            {
                ProfileName = up2.Name,
                UserId = up2.User.Id,
                Name = up2.User.Name,
            };
    var results = y.ToList();
