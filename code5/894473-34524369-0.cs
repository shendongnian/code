    // FormData is a custom container type that holds data... you'll have your own.
    public static void FillOutForm(FormData data)
    {
        var app = new Microsoft.Office.Interop.Word.Application();
        Microsoft.Office.Interop.Word.Document doc = null;
        try 
        {
            var filePath = "Your file path.";
            doc = app.Documents.Add(filePath);
            doc.Activate();
            // Loop over the form fields and fill them out.
            foreach(Microsoft.Office.Interop.Word.FormField field in doc.FormFields)
            {
                switch (field.Name)
                {
                    // Text field case.
                    case "textField1":
                        field.Range.Text = data.SomeText;
                        break;
                    // Check box case.
                    case "checkBox1":
                        field.CheckBox.Value = data.IsSomethingTrue;
                        break;
                    default:
                        // Throw an error or do nothing.
                        break;
                }
            }
            // Save a copy.
            var newFilePath = "Your new file path.";
            doc.SaveAs2(newFilePath);
        }
        catch (Exception e)
        {
            // Perform your error logging and handling here.
        } 
        finally
        {
            // Make sure you close things out.
            // I tend not to save over the original form, so I wouldn't save 
            // changes to it -- hence the option I chose here.
            doc.Close(
                Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);
            app.Quit();
        }
    }
