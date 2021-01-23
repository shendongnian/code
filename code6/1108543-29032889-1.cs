    DateTime temp;
    if(!DateTime.TryParse(group.GroupDateTime, out temp))
    {
        this.ModelState.AddError(....);
        return /* add action result here */
    }
    
    if(temp < DateTime.Now)
    {
        this.ModelState.AddError(....)
        return /* add action result here */
    }
    
    ...everything else...
