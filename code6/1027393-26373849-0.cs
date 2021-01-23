    public WorkOrderDependencyViewModel ConvertClassToViewModel(
        WorkOrderDependency entity)
    {
        return new WorkOrderDependencyViewModel 
        {
            Id = entity.Id,
            WorkOrderHeaderId = entity.WorkOrderHeaderId,
            POHeaderId = entity.PODetail.POHeaderId,
            RemainQty = x.PODetail.QtyOrdered - x.PODetail.QtyReceived
        };
    {
