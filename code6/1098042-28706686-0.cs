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
            bool ok = ofd.ShowDialog() == DialogResult.OK;
            Result = ofd.FileName;
            return ok;
        }
    }
    public class FolderDialog : FileFolderDialogBase
    {
        public override bool ShowDialog()
        {
            var fbd = new FolderBrowserDialog();
            bool ok = fbd.ShowDialog() == DialogResult.OK;
            Result = fbd.SelectedPath;
            return ok;
        }
    }
