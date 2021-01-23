    private void button1_Click(object sender, EventArgs e)
        {
            //Open folder browser for user to select the folder to scan
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Clear text fields
                listBoxResults.Items.Clear();
                listBoxPath.Items.Clear();
                txtFoldersFound.Clear();
                //Store selected folder path
                string dirPath = folderBrowserDialog1.SelectedPath;
                Action<string> performOnEachFolder = (s) => this.Invoke(new Action(() => listUpdate2(s)));
                foreach (string emptyFolder in GetAllEmptyFolders(dirPath, performOnEachFolder))
                    this.Invoke(new Action(() => listUpdate2(emptyFolder)));
            }
        }
        private static IEnumerable<string> GetAllEmptyFolders(string path, Action<string> performOnEachFolder)
        {
            performOnEachFolder(path);
            EmptyResult result = IsDirectoryEmpty(path);
            if (result == EmptyResult.Empty)
                yield return path;
            if (result == EmptyResult.Error)
                yield break;
            //A reparse point may indicate a recursive file structure. Cause this to stop the recursion. 
            //http://blogs.msdn.com/b/oldnewthing/archive/2004/12/27/332704.aspx
            if ((File.GetAttributes(path) & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint)
                yield break;
            IEnumerator<string> it = Directory.EnumerateDirectories(path, "*.*", SearchOption.TopDirectoryOnly).GetEnumerator();
            while (it.MoveNext())
            {
                foreach (string emptyFolder in GetAllEmptyFolders(it.Current, performOnEachFolder))
                {
                    yield return emptyFolder;
                }
            }
        }
        private enum EmptyResult
        {
            Empty = 1,
            Used = 2,
            Error = 3
        }
        private static EmptyResult IsDirectoryEmpty(string path)
        {
            try
            {
                return !Directory.EnumerateFileSystemEntries(path).Any() ? EmptyResult.Empty : EmptyResult.Used;
            }
            catch (UnauthorizedAccessException)
            {
                //We do not want the method to throw as that will cause problems with the iterator block.
                return EmptyResult.Error;
            }
        }
