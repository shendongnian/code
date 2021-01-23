        private void Form1_DragEnter(object sender, DragEventArgs e) {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files) {
                var ext = System.IO.Path.GetExtension(file);
                if (ext.Equals(".xlsx", StringComparison.CurrentCultureIgnoreCase) ||
                    ext.Equals(".txt",  StringComparison.CurrentCultureIgnoreCase)) {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
        }
