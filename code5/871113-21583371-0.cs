    var r = firstDesc ? 
    filteredTags
    .OrderByDescending(t => getColumnName(iSortCol_1))
    : filteredTags
    .OrderBy(t => getColumnName(iSortCol_1))
    for ( var i =1;  i < colCount; i++)
    {
        r = nDesc ? 
        r.ThenByDescending(t => getColumnName(iSortCol_1))
        : r.OrderBy(t => getColumnName(iSortCol_1))
    }
