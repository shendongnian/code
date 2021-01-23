    object index = (object)i;
    Microsoft.Office.Interop.Excel.Hyperlink link = links.get_Item(index);
    string absolutePath = System.IO.Path.GetFullPath(xlpath+link.Address);
    Debug.WriteLine(absolutePath);
    Bitmap image = (Bitmap) Image.FromFile(absolutePath,true);
