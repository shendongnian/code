    class SaveGame
    {
        SaveGame(StorageFile file)
        {
            File = file;
        }
    
        public async Task<SaveGame> Create()
        {
            return new SaveGame(await promptUser());
        }
    }
    SaveGame g = await SaveGame.Create();
