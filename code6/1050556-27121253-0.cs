        private async void RefreshButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StorageFolder sFolder = 
                await StorageFolder.GetFolderFromPathAsync((DataContext as MainPageVM).ParentFolder);
            List<string> fileTypeFilter = new List<string>();
            fileTypeFilter.Add(".pnsm");
            fileTypeFilter.Add(".pssm");
            
            QueryOptions queryOptions =
                new QueryOptions(CommonFileQuery.OrderByName, fileTypeFilter);
            StorageFileQueryResult results = sFolder.CreateFileQueryWithOptions(queryOptions);
            var files = await results.GetFilesAsync();
            List<string> paths = files.Select(x => x.Path.ToString()).ToList();
            SaveSearch();
        }
