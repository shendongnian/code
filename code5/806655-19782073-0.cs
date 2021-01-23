    ProductType prodObj = new ProductType
    {
        Name="name",
        Description= "description",
        Excerpt ="excerpt",
        Image= new Image //you can directly assign your image object here
        {
            Name="name",
            ImageData=new ImageData
            {
                Data=new byte[0]; //use your data
            }
        }
    };
    
    using(Context ctx = new Context())
    {
        ctx.ProductTypes.add(prodObj);
        ctx.saveChanges();
        return prodObj;
    }
