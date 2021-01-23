    foreach (JObject obj in arr)
    {
        id = obj["Id"] as string;
        packSize = obj["PackSize"] as short?;
        var description = obj["Description"] as string;
        var deptSubdept = obj["DeptDotSubdept"] as double?;
        var unitCost = obj["Unit_Cost"] as decimal?;
        var unitList = obj["Unit_List"] as decimal?;
        var UPC_Code = obj["UPC_code"] as string;
        var UPC_packSize = obj["UPC_pack_size"] as short?;
        var CRVId = obj["CRV_Id"] as int?;
        inventoryItems.Add(new WebAPIClientUtils.InventoryItem
        {
            Id = id ?? string.Empty,
            PackSize = packSize.GetValueOrDefault(),
            Description = description ?? string.Empty,
            DeptDotSubdept = deptSubdept.GetValueOrDefault(),
            Unit_Cost = unitCost.GetValueOrDefault(),
            Unit_List = unitList.GetValueOrDefault(),
            UPC_code = UPC_Code ?? string.Empty,
            UPC_pack_size = UPC_packSize.GetValueOrDefault(),
            CRV_Id = CRVId.GetValueOrDefault()
        });
    }
