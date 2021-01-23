    (from a in context.A
    where a.Roles.Any(r=>r.RoleName == "ADMIN")
    select new {Name = a.Name, Age = a.Age, Role = "ADMIN", Employed = a.IsEmployed})
    .Union(
    from b in context.B
    where b.Roles.Any(r=>r.RoleName == "ADMIN")
    select new {Name = b.Name, Age = b.Age, Role = "ADMIN".RoleName, Employed = "-"}
    )
