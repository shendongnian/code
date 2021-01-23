    private RelayCommand<DragEventArgs> _dropFiles;
    
    /// <summary>
    /// Gets the DropFiles.
    /// </summary>
    public RelayCommand<DragEventArgs> DropFiles
    {
        get
        {
            return _dropFiles
                ?? (_dropFiles = new RelayCommand<DragEventArgs>(
                args =>
                {
                    if (args.Data.GetDataPresent(DataFormats.FileDrop))
                    {
                        // Note that you can have more than one file.
                        string[] files = (string[])args.Data.GetData(DataFormats.FileDrop);
                        if ((args.OriginalSource as FrameworkElement).DataContext is MyFolder)
                        {
                          //put the files in a folder
                        }
                        else
                        {
                           //do something else
                        }
                    }
                }
        }
    }
