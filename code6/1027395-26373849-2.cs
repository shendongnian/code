    private static readonly Expression<Func<WorkOrderDependency, WorkOrderDependencyViewModel>> AsViewModel =
        entity => new WorkOrderDependencyViewModel
            {
                Id = entity.Id,
                WorkOrderHeaderId = entity.WorkOrderHeaderId,
                POHeaderId = entity.PODetail.POHeaderId,
                RemainQty = entity.PODetail.QtyOrdered - entity.PODetail.QtyReceived
            };
