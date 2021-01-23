    //Dictionary to store the pairs of `text` and the corresponding image
    Dictionary<string, Image> dict = new Dictionary<string, Image>(StringComparer.CurrentCultureIgnoreCase);
    //load data for your dict
    dict["Unknown"] = yourUnknownImage;//This should always be added
    dict[".pdf"] = yourPdfImage;
    dict[".txt"] = yourTxtImage;
    //.....
    //CellPainting event handler for your dataGridView1
    //Suppose the column at index 1 is the type column.
    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e){
       if(e.ColumnIndex == 1 && e.RowIndex > -1){
         var image = dict["Unknown"];
         if(e.Value != null) {
            var entry = dict.FirstOrDefault(x=>e.Value.EndsWith(x.Key));
            if(entry != null) image = entry.Value;
         }
         //Draw the image
         e.Graphics.DrawImage(image, new Rectangle(2,2, e.Bounds.Height-4, e.Bounds.Height-4));
       }
    }
