    private void SearchFolder(PortableDeviceFolder parent,
        List<PortableDeviceFolder> result, string fileName, IProgress<int> progress)
    {
        foreach (var item in parent.Files)
        {
            PortableDeviceFolder folder = item as PortableDeviceFolder;
            if (folder != null)
            {
                SearchFolder(folder, result, fileName, progress);
            }
            else if (item.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(parent);
            }
        }
        progress.Report(1);
    }
