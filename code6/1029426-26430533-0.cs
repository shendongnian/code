    List<int> newImageList;
    
    for(int i = 0; i < CurrentImage.Header.Height)
    {
       newImageList.AddRange(PPMImageLibrary.GrayscaleImage(CurrentImage.ImageListData).ToEnumerable()); // I am assuming your GrayscaleImage method might return multiple records.
        
    }
    
    public static IEnumerable<TItemType> ToEnumerable<TItemType>(this FSharpList<TItemType> fList)
    {
       return Microsoft.FSharp.Collections.SeqModule.OfList<TItemType>(fList);
    }
