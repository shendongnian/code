    Dictionary<string, string> equalitySearchCriteria = new Dictionary<string, string>();
    equalitySearchCriteria.Add("TrainingProgram Code", ddlSearch.Text);
    equalitySearchCriteria.Add("District",ddlDistrict.SelectedItem.Text);
    // Add other items
    
    Dictionary<string, string> likeSearchCriteria = new Dictionary<string, string>();
    likeSearchCriteria.Add("Province", ddlProvince.SelectedItem.Text.ToLower());
    // Add other items
    
    var query = attributesData.Where(x => x);
    
    foreach(var criterion in equalitySearchCriteria)
    {
       var equalityJoinQuery = attributesData.Where(x => x.attributeName == criterion.Key && x.strValue == criterion.Key);
       query = query.Join(equalityJoinQuery, x => x.strFormId, y => y.strFormId, (x, y) => x);
    }
    
    foreach(var criterion in likeSearchCriteria)
    {
       var likeJoinQuery = attributesData.Where(x => x.attributeName == criterion.Key && x.strValue.Contains(criterion.Key));
       query = query.Join(likeJoinQuery, x => x.strFormId, y => y.strFormId, (x, y) => x);
    }
    
    var result = query.Select(t => t.strFormId).Distinct().ToList();
