    using System;
    using System.Windows.Forms;
    namespace ConsoleApplication2
    {
        class Program
        {
            [STAThread]
            private static void Main()
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.FileOk += (sender, args) =>
                    {
                        var dlg = (FileDialog) sender;
                        if (dlg.FileName.IndexOfAny("+#%-".ToCharArray()) >= 0)
                            return;
                        MessageBox.Show("Invalid character in filename: " + dlg.FileName);
                        args.Cancel = true;
                    };
                    dialog.ShowDialog();
                }
            }
        }
    }
