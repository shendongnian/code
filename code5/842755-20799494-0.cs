    class Program
    {
        [STAThread]
        static void Main()
        {
            string path = "";
            var fileDialog = new FolderBrowserDialog();
            var result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = fileDialog.SelectedPath;
            }
            Console.WriteLine(path);
        }
    }
