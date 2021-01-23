    private void SearchFolder(PortableDeviceFolder parent, List<PortableDeviceFolder> result, string fileName)
    {
        foreach (var item in parent.Files)
        {
            PortableDeviceFolder folder = item as PortableDeviceFolder;
            if (folder != null)
            {
                SearchFolder(folder, result, fileName);
            }
            else if (item.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(parent);
            }
        }
        Dispatcher.Invoke(() => progressBar1.Value += 1);
    }
