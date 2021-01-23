    var ctx = new ApplicationDbContext();
    var user = HttpContext.Current.User;
    var userId = user.Identity.GetUserId();
        var roles =
          ctx.Roles.Where(a => a.Users.Select(b => b.UserId).ToList().Contains(userId))
            .ToList();
