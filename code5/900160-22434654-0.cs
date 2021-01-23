    {
        ID = c.ID,
        address = c.address,
        category = new Model.CenterShopCat
        {
            ID = c.CenterShopCat.ID,
            name = c.CenterShopCat.name
        },
        floorNumber = c.floorNumber,
        images = new List<CenterShopImage>() 
        {
            new CenterShopImage{...},
            new CenterShopImage{...},
            ...
        },
    };
