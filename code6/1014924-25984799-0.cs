        public Window1()
        {
            InitializeComponent();
            // mainRTB is the name of my RichTextBox.
            mainRTB.PreviewDragEnter += new DragEventHandler(mainRTB_PreviewDragEnter);
            mainRTB.PreviewDragOver += new DragEventHandler(mainRTB_PreviewDragEnter);
            
            mainRTB.PreviewDrop += new DragEventHandler(mainRTB_PreviewDrop);
            mainRTB.AllowDrop = true;
        }
        static bool IsImageFile(string fileName)
        {
            return true;  // REPLACE THIS STUB WITH A REAL METHOD.
        }
        void mainRTB_PreviewDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null && files.Length > 0)
                {
                    // Filter out non-image files
                    if (mainRTB.Document.PasteImageFiles(mainRTB.Selection, files.Where(IsImageFile)))
                        e.Handled = true;
                }
            }
        }
        void mainRTB_PreviewDragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            // Filter out non-image files
            if (files != null && files.Length > 0 && files.Where(IsImageFile).Any())
            {
                // Consider using DragEventArgs.GetPosition() to reposition the caret.
                e.Handled = true;
            }
        }
