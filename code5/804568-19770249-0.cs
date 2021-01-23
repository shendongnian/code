    public void ImportDemo(IEnumerable<Demo> demos)
    {
       foreach (var demo in demos)
       {
           foreach (var child in demo.Children)
           {
               child.Item = 
                   dbContext.Items.Local.First(p => p.Id == child.Item.Id)
           }
           dbContext.Set<Demo>.Add(demo);
       }
       dbContext.SaveChanges();
    }
