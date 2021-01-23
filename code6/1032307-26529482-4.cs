    public OrderDTO GetNextOrderNotDownloaded()
    {
        return _context.Orders
                    .Include(o => o.OrderLines)
                    .Where(o => !o.IsDownloaded)
                    .OrderBy(o => o.DateCreated)
                    .Select(o => new OrderDTO { Id = o.Id, Orders = o.OrderLines})
                    .FirstOrDefault();
    }
