    if( imageCollectionItem != null )
    {
        return ((IBaseImage)imageCollectionItem).Image; // Compiles fine
        return (IBaseImage)imageCollectionItem.Image; // Fails
    }
