    var ordered = items.Join(ItemMetrics,
                             item => item.ItemId,
                             metric => metric.ItemId,
                             (item, metric) => new { item, metric })
                       .OrderBy(pair => pair.Metric.Weight);
    var paged = ApplyPaging(ordered, pageConfiguration); // Whatever
    var query = paged.Select(pair => pair.Item);
