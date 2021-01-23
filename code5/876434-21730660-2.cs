    public override bool UpdateItem(DbUser item)
    {
    	Work.Context.ReAttach(item);    
    	Work.Context.Entry(item).State = EntityState.Modified;    
    	return Work.Context.Entry(item).GetValidationResult().IsValid;
    }
