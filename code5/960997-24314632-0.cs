    using ( var ctx = new Model()) 
    {
       var item1 = ctx.ItemA.FirstOrDefault(i => i.Id == itemAId);
       var item2 = ctx.ItemB.FirstOrDefault(j => j.Id == itemBId);
       item1.ItemBs.Add(item2);
       ctx.SaveChanges();
    }
