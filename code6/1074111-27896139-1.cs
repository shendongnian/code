    foreach (var innerItem in resultItems.data)
    {
        if (innerItem.name == "MoneyNote.db")
        {
            StorageFile downFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("MoneyNote.db", CreationCollisionOption.ReplaceExisting);
            var result = await liveConnectClient.BackgroundDownloadAsync(innerItem.id + "/content", downFile);
            messagePrint(true);
        }
    }
