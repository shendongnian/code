    // Get the Range for the text you want to replace, which you claim to be able to do already.
    Word.Range selectedText = GetTextToReplace();
    // Clear the existing text, otherwise the image will just be appended after the text.
    selectedText.Text = "";
    // Insert the image.
    selecetdText.InlineShapes.AddPicture(imagePath, Type.Missing, true, Type.Missing);
