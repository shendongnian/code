    using System.Linq;
    // Query all files in the folder. Make sure to add the CommonFileQuery
    // So that it goes through all sub-folders as well
    var folders = ApplicationData.LocalFolder.CreateFileQuery(CommonFileQuery.OrderByName);
    // Await the query, then for each file create a new Task which gets the size
    var fileSizeTasks = (await folders.GetFilesAsync()).Select(async file => (await file.GetBasicPropertiesAsync()).Size);
    // Wait for all of these tasks to complete. WhenAll thankfully returns each result
    // as a whole list
    var sizes = await Task.WhenAll(fileSizeTasks);
    // Sum all of them up. You have to convert it to a long because Sum does not accept ulong.
    var folderSize = sizes.Sum(l => (long) l);
