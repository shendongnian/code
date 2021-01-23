	var query =
        queryable
            .Join(confQueryable, p => p.Id, c => c.Id, (p, c) => new {p, c})
            .Where(exp)
            .Where(@t => p.ParentId == parentProcessId)
            .Select(@t => new {@t, hasChild = p.Processes.Any()})
            .Select(@t => new ViewModel
            {
                Code = p.Code,
                Text = string.Format("{0}: {1}", c.Name, p.Name), // use c variable
                ParentId = p.Id,
                Value = p.Id.ToString(),
                HasChildren = hasChild, // use hasChild variable
            });
