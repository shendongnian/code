    var productTypes = productType.Split(',');
    //if you need to get matched policies
    var matchedPolicies = policies
        .Where(x => x.summaries.Any(y => productTypes.Contains(y.serviceName)));
    //if you need to get matched summaries
    var matchedSummaries = policies.SelectMany(x => x.summaries)
        .Where(x => productTypes.Contains(x.serviceName));
