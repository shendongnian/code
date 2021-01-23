    public class MyDbContext : DbContext
    { 
      DbSet<Order> Order { get; set; }
      DbSet<Item> Items { get; set; }
    |
    // each of these orders do not contain any
    // items, we did not .Include() them.
    var supplierOrders = db.Orders
      .Where(o => o.Items
                   .Any(i => i.SupplierId == 1))
      .ToList();
    var orderIds = supplierOrders
      .Select(so => so.Id)
      .ToList();
    var supplierItems = db.Items.
      .Where(i => orderIds.Contain(i.SupplierId))
      .ToList();
