    private static byte[] CreateImage(string text, int fontSize, int width, int height) {
        using (var b = new Bitmap(width, height)) {
            using (var g = Graphics.FromImage(b)) {
                using(var br = new SolidBrush(System.Drawing.Color.Red)){
                    using (var f = new System.Drawing.Font("Arial Unicode MS", fontSize)) {
                        g.DrawString(text, f, br, 10, 10);
                        using (var ms = new System.IO.MemoryStream()) {
                            b.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                            return ms.ToArray();
                        }
                    }
                }
            }
        }
    }
