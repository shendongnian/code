    Image[,] images = new Image[20,20];
    for (i = 1; i <= images.GetLength(0); i++)
    {
        for (j = 1; j <= images.GetLength(1); j++)
        {
             images = (Image)Tileset.ResourceManager.getObject(string.format("image_resource_name_{0}_{1}", i ,j));                          
        }
    }
