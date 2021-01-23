        private void treeView1_NodeMouseDoubleClick(object sender,                 TreeNodeMouseClickEventArgs e)
        {
            if (CheckIfPathIsFile(e.Node.Tag.ToString()) == true) //If the Tag (Path) is a File
            {
                //Do something with the Path (close this Form + return Path)
            }
        }
        private bool CheckIfPathIsFile(string Path)
        {
            // get the file attributes for file or directory
            FileAttributes attr = File.GetAttributes(Path);
            //detect whether its a directory or file
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                return false;
            else
                return true;
        }
