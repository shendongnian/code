    List<ProductData> data = m_Context.ProductData.Where(w => w.Id == data.Id).ToList();
    
    if (data.Count() == 0)
    {
       m_Context.ProductData.Attach(data);
    }
    
    m_Context.ProductData.Remove(data); 
