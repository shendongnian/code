    class AChild : BaseClass
    {
        AChild()
        {
             if (!TextureImage.ContainsKey(typeof(AChild)))
                 TextureImage.Add(typeof(AChild), LoadTexture(PathToImageA));
        }
    }
    
    class BChild : BaseClass
    {
        BChild()
        {
             if (!TextureImage.ContainsKey(typeof(BChild)))
                 TextureImage.Add(typeof(BChild), LoadTexture(PathToImageB));
        }
    }
