    return someQueryable
        .Where(version => version.Order.AlgoVersions.Any(v => (allowUncommittedVersions || v.Statuses.Any(s => s.AlgoVersionStatusListItemId == ModelConstants.AlgoVersionCommitted_StatusId)) && v.Id != version.Id))
        .Select(version => new AlgoVersionCacheItem
            {
                OrderId = version.OrderId,
                OrderTitle = version.Order.Title,
                    CurrentVersion = version.Order.CurrentAlgoVersionId,
                    CachedVersion = version.Id,
                    AvailableVersions = version
                        .Order
                        .AlgoVersions
                        .Where(v => (allowUncommittedVersions || v.Statuses.Any(s => s.AlgoVersionStatusListItemId == ModelConstants.AlgoVersionCommitted_StatusId)) && v.Id != version.Id)
                        .OrderByDescending(v => v.Id) // this line will cause exception
                        .Select(v => v.Id)
            })
        .OrderByDescending(item => item.OrderId)
        .ToArray();
