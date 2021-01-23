    public void SaveInfoToDBFromFiles(string path, IProgress<int> progress) {
        // .. other code here ..
        var i = 0;
        foreach (var file in path) {
            progress.Report(i);
            i++;
        }
    }
