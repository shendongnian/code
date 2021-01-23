    //File to create
    var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
    //Standard PDF creation, nothing special here
    using (var fs = new FileStream(testFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, fs)) {
                doc.Open();
                //Create a root form object that we'll add "children" to. This way we don't have to add each "child" annotation to the writer
                var root = PdfFormField.CreateEmpty(writer);
                root.FieldName = "root";
                //Create a two column table
                var t = new PdfPTable(2);
                
                //Add a basic cell
                t.AddCell("First Name");
                //Create our textfield, the rectangle that we're passing in is ignored and doesn't matter
                var tf = new TextField(writer, new iTextSharp.text.Rectangle(0, 0), "first-name");
                //Create a new cell
                var cell = new PdfPCell();
                //Set the cell event to our custom IPdfPCellEvent implementation
                cell.CellEvent = new ChildFieldEvent(root, tf.GetTextField(), 1);
                //Add the cell to our table
                t.AddCell(cell);
                //Add the table to the document
                doc.Add(t);
                //IMPORTANT! Add the root annotation to the writer which also adds all of the child annotations
                writer.AddAnnotation(root);
                //Clean up
                doc.Close();
            }
        }
    }
