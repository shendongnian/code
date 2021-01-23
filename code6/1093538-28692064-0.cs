    using (var mem = new MemoryStream(img.Data))
    {
        System.Drawing.Image sysImg = System.Drawing.Image.FromStream(mem, false, true);
        var ximg = PdfSharp.Drawing.XImage.FromGdiPlusImage(sysImg);
        args.Callback(ximg);
    }
