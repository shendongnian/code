    private Industry GetIndustryById(List<Industry> IndustryList, int? id)
    {
        if (id != null)
        {
            foreach (Industry industry in IndustryList)
            {
                if (industry.id == id)
                {
                    return industry;
                }
            }
            foreach (Industry industry in IndustryList)
            {
                if (industry.industryList != null)
                {
                    // Here was your mistake. If you return GetIndustryById()
                    // without checking for null first, you will return null
                    // if that subtree doesn't contain the target, even if
                    // a subsequent subtree does.
                    
                    var result = GetIndustryById(industry.industryList, id);
                    
                    if (result != null)
                        return result;
                }
            }
        }
        return null;
    }
