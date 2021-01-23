    //Make sure this annotation has an ACTION
    if (AnnotationDictionary.Get(PdfName.A) == null)
        continue;
    //Remove our old action entry just so nothing weird hangs around
    AnnotationDictionary.Remove(PdfName.A);
    //Create a new action entry
    var a = new PdfDictionary(PdfName.A);
    //Set it as an action
    a.Put(PdfName.TYPE, PdfName.ACTION);
    //Set it as JavaScript
    a.Put(PdfName.S, PdfName.JAVASCRIPT);
    //Set the JavaScript
    a.Put(PdfName.JS, new PdfString(@"app.alert('Hello World');"));
    //Add it back to the annotation
    AnnotationDictionary.Put(PdfName.A, a);
