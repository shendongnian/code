        [TestInitialize]
        async public Task TestDatabaseInitilize()
        {
            //manually copied data from 
            var site = "SMEPS_SM_SealBeach_Test";
            var appx = Package.Current.InstalledLocation;
            var reposTestFolder = await appx.GetFolderAsync(site);
            var testFiles = await reposTestFolder.GetFilesAsync();
            var localfolder = ApplicationData.Current.LocalFolder;
            var reposFolder = await localfolder.CreateFolderAsync(site, CreationCollisionOption.OpenIfExists);
            foreach (var file in testFiles)
            {
                await file.CopyAsync(reposFolder);
            }
        }
