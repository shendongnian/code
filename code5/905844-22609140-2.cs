    enter code here
    private async void CheckIfExist()
	    {
	        try
	        {
	            var isoStore = FileSystem.Current.LocalStorage;
            
	            var folder = await isoStore.CreateFolderAsync("xxx", 
    CreationCollisionOption.ReplaceExisting);                
	            
                ExistenceCheckResult result = await  isoStore.CheckExistsAsync("xxx");
	            switch (result)
	            {
	                case (ExistenceCheckResult.FolderExists):
	                    Console.WriteLine(":)"); break;
	                case (ExistenceCheckResult.NotFound):
	                    Console.WriteLine(":("); break;
	            }
	        }
	        catch (Exception)
	        {
	            Console.WriteLine(":<");
	        }
	    }'
