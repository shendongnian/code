    public async Task InitAsync(Data.Posts.Content2 manga){
        var folder = ApplicationData.Current.LocalFolder;
            var safeName = Path.GetInvalidFileNameChars().Aggregate(manga.ContentInfo.ContentName, (current, c) => current.Replace(c, '_').Replace('.', '_'));
    
            // Create folder for issue if does not exist
            var issueFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(safeName, CreationCollisionOption.OpenIfExists);
            // Create folder for language if does not exist
            var langFolder = await issueFolder.CreateFolderAsync(manga.ContentInfo.ContentLanguage, CreationCollisionOption.OpenIfExists);
    
            // Populate pages if page count is 0
            if (manga.Pages == null)
                manga.Pages = new Dictionary<int, Data.Posts.Page>();
            if (manga.Pages.Count == 0)
            {
                var pages = Fakku.GetMangaInfo(manga.ContentInfo.ContentUrl).Result.Pages;
                for (var i = 0; i < pages.Count; i++)
                {
                    var page = new Data.Posts.Page { Image = pages.Values.ElementAt(i).Image, Thumb = pages.Values.ElementAt(i).Thumb };
                    manga.Pages.Add(i, page);
                }
            }
         
            var cbi = new BitmapImage(new Uri(manga.ContentInfo.ContentImages.Cover));
            const string cname = "cover.jpg";
            var wcbi = await WriteableBitmapFromBitmapImageExtension.FromBitmapImage(cbi);
            await wcbi.SaveToFile(langFolder, cname, CreationCollisionOption.OpenIfExists);
    
    
            var sbi = new BitmapImage(new Uri(manga.ContentInfo.ContentImages.Sample));
            const string sname = "sample.jpg";
            var wsbi = await WriteableBitmapFromBitmapImageExtension.FromBitmapImage(sbi);
            await wsbi.SaveToFile(langFolder, sname, CreationCollisionOption.OpenIfExists);
    }
