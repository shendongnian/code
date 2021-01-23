     destinationObject = MyObjectList.Select(x =>
            new ObjectToSelectInto()
            {
               AllProductColors = MyObjectList.Select(y => y.ProductName).ToList(),
               ImgUrl = x.ImgUrl,
               ProductName = x.ProductName
           }).First();
