    private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Bitmap bitmap = ImageToBitmap(e.Source as System.Windows.Controls.Image);
     
        DataObject data = new DataObject(DataFormats.EnhancedMetafile, MakeMetafileStream(bitmap));
     
        DragDrop.DoDragDrop((DependencyObject)e.Source, data, DragDropEffects.Copy);
    }
