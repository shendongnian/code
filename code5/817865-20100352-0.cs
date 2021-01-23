    var ImageSignatures = new List<byte[]>();
    // BITMAP_ID_BLOCK = "BM"
    ImageSignatures.Add(new byte[] { 0x42, 0x4D });
    // JPG_ID_BLOCK = "\u00FF\u00D8\u00FF"
    ImageSignatures.Add(new byte[] { 0xFF, 0xD8, 0xFF });
    // PNG_ID_BLOCK = "\u0089PNG\r\n\u001a\n"
    ImageSignatures.Add(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A });
    // GIF_ID_BLOCK = "GIF8"
    ImageSignatures.Add(new byte[] { 0x47, 0x49, 0x46, 0x38 });
    // TIFF_ID_BLOCK = "II*\u0000"
    ImageSignatures.Add(new byte[] { 0x49, 0x49, 0x2A, 0x00 });
