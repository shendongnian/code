    List<Company> companies ...
    List<IndustryNode> industries = comapanies.Select(c => c.Industry).Distinct()
                              .Select(c => new IndustryNode() {
                                            IndustryName = c.IndustryName,
                                            ChildIndustryNodes = c.ChildIndustries.ToArray()
                                       }).ToList();
