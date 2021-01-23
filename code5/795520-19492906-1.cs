    context.Classes.Where(c => /* condition goes here */)
        .SelectMany(c => c.Courses)
        .Select(cs =>
            new
            {
                Name = cs.Name,
                Class = cs.Class.Name
            });
