    IQueryable<Model> query = DBContext.Model;
    
    if(_ModelCode != -1)
    {
        query = query.Where(data=>data.ModelCode==_ModelCode);
    } 
    
    if(_ProductCode!= -1)
    {
        query = query.Where(data=>data.ProductCode==_ProductCode);
    } 
    
    if(_SectionCode!= -1)
    {
        query = query.Where(data=>data.SectionCode==_SectionCode);
    } 
