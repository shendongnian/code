    private void richTextBoxOutput_TextChanged(object sender, EventArgs e)
    {
        UpdateEmoticon();
    }
    private void UpdateEmoticon(int startIndex = 0)
    {
        const string smileKey = ":)";
        const int smileKeyLen = 2;
        DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
        var index = richTextBoxOutput.Find(smileKey, startIndex, RichTextBoxFinds.None);
        if (index == -1)
            return;
        richTextBoxOutput.Select(index, smileKeyLen);
        using (var bmp = new Bitmap(Resources.smile))
        {
            Clipboard.SetDataObject(bmp);
            if (richTextBoxOutput.CanPaste(myFormat))
            {
                richTextBoxOutput.Paste(myFormat);
            }
        }
        UpdateEmoticon(startIndex + smileKeyLen);
    }
