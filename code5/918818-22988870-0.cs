    public void Work()
    {
        Parallel.ForEach(order.SubOrders, ExecuteSubOrder);
    }
    public void ExecuteSubOrder(SubOrder subO)
    {
        // ... execute suborder, some webrequest etc.
        ordersCompletedTable.Execute(TableOperation.Insert(new SubOrder(subO.SubOrderId, subO.Status)),
            new TableRequestOptions() { RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(3), 3) });
    }
