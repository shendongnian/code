    var downStream = statusStream
        .Aggregate<WebsiteStatus, IEnumerable<string>>(new string[0], (down, newStatus) =>
        {
            if (newStatus.IsUp)
                return down.Where(uri => uri != newStatus.Uri);
            else if (!down.Contains(newStatus.Uri))
                return down.Concat(new string[] { newStatus.Uri });
            else
                return down;
        });
    var upStream = statusStream
        .Aggregate<WebsiteStatus, IEnumerable<string>>(new string[0], (up, newStatus) =>
        {
            if (!newStatus.IsUp)
                return up.Where(uri => uri != newStatus.Uri);
            else if (!up.Contains(newStatus.Uri))
                return down.Concat(new string[] { newStatus.Uri });
            else
                return up;
        });
    var allDown = upStream.Select(up => !up.Any());
