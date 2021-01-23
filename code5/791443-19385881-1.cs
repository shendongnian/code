    Dictionary<String, IndustryNode> index = new Dictionary<String, IndustryNode>();
    
    public void insert(Company company)
    { 
        if(index.ContainsKey(company.Industry.IndustryName))
        {
            index[company.Industry.IndustryName].hits++;
        }
        else
        {
            IndustryNode node = new IndustryNode(IndustryName=company.Industry, Hits=1);
            index[node.IndustryName] = node;
            if(index.ContainsKey(company.Industry.ParentIndustry.IndustryName))
            {
                index[company.Industry.ParentIndustry.IndustryName].ChildrenIndustries.Add(node);
            }
        }    
    }
    
    List<IndustryNode> topLevelNodes = index
        .Where(kvp => kvp.Item.ParentIndustry == null)
        .ToList(kvp => kvp.Item);
