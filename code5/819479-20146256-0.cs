    public Image ExtractBaseImage(Bitmap resultImage, Bitmap blendImage) {
        Bitmap bm = new Bitmap(resultImage.Width, resultImage.Height);
        for (int i = 0; i < resultImage.Width; i++) {
            for (int j = 0; j < resultImage.Height; j++) {
               Color resultColor = resultImage.GetPixel(i, j);
               Color blendColor = blendImage.GetPixel(i, j);
               if (blendColor.A == 0) bm.SetPixel(i, j, resultColor);
               else if(blendColor != resultColor){
                  float opacity = blendColor.A / 255f;
                  int r = Math.Max(0,Math.Min(255,(int) ((resultColor.R - (opacity) * blendColor.R) / (1-opacity))));
                  int g = Math.Max(0,Math.Min(255,(int)((resultColor.G - (opacity) * blendColor.G) / (1-opacity))));
                  int b = Math.Max(0,Math.Min(255,(int)((resultColor.B - (opacity) * blendColor.B) / (1-opacity))));                        
                  bm.SetPixel(i,j,Color.FromArgb(r,g,b));
               }
            }
        }
        return bm;
    }
