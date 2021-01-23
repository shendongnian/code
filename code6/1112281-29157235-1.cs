    db.DropTable<PlayerEquipment>();
    db.DropTable<ItemData>();
    db.CreateTable<ItemData>();
    db.CreateTable<PlayerEquipment>();
    var item1 = new ItemData { Data = "ITEM1" };
    db.Save(item1);
    db.Save(new PlayerEquipment
    {
        PlayerId = 1,
        ItemId = item1.Id,
        Quantity = 1,
        IsEquipped = true,
    });
    var item2 = new ItemData { Data = "ITEM2" };
    db.Save(item2);
    db.Save(new PlayerEquipment
    {
        PlayerId = 1,
        ItemId = item2.Id,
        Quantity = 1,
        IsEquipped = false,
    });
    var playerId = 1;
    var results = db.LoadSelect<PlayerEquipment>(q => q.PlayerId == playerId);
    results.PrintDump();
