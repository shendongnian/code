    select DeliveryNote.DeliveryNoteNumber, COUNT(Distinct(SalesOrderLine.ProductID)), Sum(DeliveryNoteLine.Quantity)
    from
    SalesOrder 
    inner join SalesOrderLine on SalesOrderLine.SalesOrderID = SalesOrder.ID and SalesOrder.IsLatestRevision = 1
    inner join DeliveryNoteLine on DeliveryNoteLine.SalesOrderLineRootID = SalesOrderLine.RootID
    inner join DeliveryNote on DeliveryNote.ID = DeliveryNoteLine.DeliveryNoteID and DeliveryNote.IsLatestRevision = 1
    group by
    DeliveryNoteNumber
    order by
    DeliveryNoteNumber
