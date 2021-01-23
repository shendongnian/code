    using System.Threading.Tasks;
    ....
    Task.Factory.StartNew(() =>
    {
        // Get IEnumerable (as in a list) on all files by recursively scanning directory.
        var fileList = Directory.EnumerateFiles(AppDirectory, "*", SearchOption.AllDirectories);
        long totalSize = 0;
        // Retrieve the size of files.
        foreach (string path in fileList)
        {
            FileInfo fileInfo = new FileInfo(path);
            long size = fileInfo.Length;
            totalSize += size;
            Invoke((Action)(()  =>
            {
                listBox1.Items.Add(path + ": " + size.ToString());
                textBox1.Text = totalSize.ToString();
            }));
        }
    });
