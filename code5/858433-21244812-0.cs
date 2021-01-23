    var items = await todoTable
                    .Where(todoItem => todoItem.Id == a)
                    .ToCollectionAsync();
    
    var item = items.FirstOrDefault();
    if(item != null)
    {
        item.street = street.Text; //
        item.colege = colege.Text; //
        await todoTable.UpdateAsync(item);
    }
