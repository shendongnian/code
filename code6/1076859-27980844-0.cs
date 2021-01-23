    if (fromDate.HasValue) {
        filterResults = filterResults
            .Where(d => d.LastModifiedAt.Date >= fromDate.Value.Date);
    }
    if (toDate.HasValue) {
        filterResults = filterResults
            .Where(d => d.LastModifiedAt.Date <= toDate.Value.Date);
    }
