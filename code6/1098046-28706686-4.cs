    public abstract class FileFolderDialogBase
    {
        public abstract bool ShowDialog();
        public string Result { get; protected set; }
    }
    public class FileDialog : FileFolderDialogBase
    {
        public override bool ShowDialog()
        {
            var ofd = new OpenFileDialog();
            if ofd.ShowDialog() == DialogResult.OK) {
                Result = ofd.FileName;
                return true;
            }
            return false;
        }
    }
    public class FolderDialog : FileFolderDialogBase
    {
        public override bool ShowDialog()
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                Result = fbd.SelectedPath;
                return true;
            }
            return false;
        }
    }
