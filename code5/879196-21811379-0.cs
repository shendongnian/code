    // Item mapping
    mapping.HasManyToMany(x => x.Ranges)
            .Table("itr_RangeItemsAssoc")
            .ParentKeyColumn("itr_ItemRangeKey") // not itm_Key
            .ChildKeyColumn("itr_ItemsKey")
            .Cascade.SaveUpdate().LazyLoad();
    // Range mapping
    mapping.HasManyToMany(x => x.Items)
            .Table("itr_RangeItemsAssoc")
            .ParentKeyColumn("itr_ItemsKey") // not itr_Key
            .ChildKeyColumn("itr_ItemRangeKey")
            .Cascade.SaveUpdate().LazyLoad()
            // here, the inverse
            .Inverse() // one end must be marked as inverse
            ;
