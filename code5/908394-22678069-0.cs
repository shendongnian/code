     public class TileManager
     {
          public const string StoragePath = "Shared/ShellContent";
     
          public static async Task SaveTileImage(Uri uri, string filename, string folder = StoragePath)
          {
               var client = new HttpClient();
     
               var isf = IsolatedStorageFile.GetUserStoreForApplication();
               if (!isf.DirectoryExists(StoragePath))
                    isf.CreateDirectory(StoragePath);
               var file = (folder == null ? filename : String.Format("{0}/{1}", folder, filename));
               if (isf.FileExists(file)) isf.DeleteFile(file);
     
               using (var stream = isf.OpenFile(file, FileMode.Create, FileAccess.ReadWrite))
               {
                    var bytes = await client.GetByteArrayAsync(uri);
                    var ms = new MemoryStream(bytes, false);
                    await ms.CopyToAsync(stream); 
               }
          }
     
          public static void UpdateCycleTile(Uri smallBackgroundImage, string folder, string[] filesToShow, ShellTile currentTile)
          {
               var cycleTile = new CycleTileData
               {
                    Title = "Stitch",
                    SmallBackgroundImage = smallBackgroundImage,
                    CycleImages = filesToShow.Select(str => String.Format("isostore:/{0}/{1}", folder, str).ToUri()).ToArray()
               };
               currentTile.Update(cycleTile);
          }
     }
