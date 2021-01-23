    public async Task SaveMangaPage(int pageNumber) {
    
     var bi = new BitmapImage(new Uri(manga.Pages[pageNumber].Image));
     //var x = await langFolder.CreateFileAsync(String.Format("{0}.png", pageNumber), CreationCollisionOption.ReplaceExisting);
     var imgName = String.Format("{0}.jpg", pageNumber);
     try
       {
      var wbi = await WriteableBitmapFromBitmapImageExtension.FromBitmapImage(bi);
      await wbi.SaveToFile(langFolder, imgName, CreationCollisionOption.OpenIfExists);
     }
     catch (Exception e)
      {
         var hResult = (uint)e.HResult;
         if (hResult.Equals(0x80190194))
         {
                        new MessageDialog("Error loading pages. \n  If this is a sample manga, this behavior is to be expected.").ShowAsync();
                        break;
          }
     }
    }
    }
