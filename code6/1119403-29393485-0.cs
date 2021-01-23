    StorageFolder folder = Windows.Devices.Portable.StorageDevice.FromId(phoneId);
    var data = new List<Tuple<string, UInt64[]>> { };
    IReadOnlyList<StorageFolder> subFolders = await folder.GetFoldersAsync();
    foreach (StorageFolder subFolder in subFolders)
    {
      var props = await subFolder.Properties.RetrievePropertiesAsync(
        new string[] { "System.FreeSpace", "System.Capacity" });
      if (props.ContainsKey("System.FreeSpace") && props.ContainsKey("System.Capacity"))
      {
        data.Add(Tuple.Create(
          subFolder.Name,
          new UInt64[] {
            (UInt64) props["System.FreeSpace"],
            (UInt64) props["System.Capacity"]
        }));
      }
    }
    return data;
