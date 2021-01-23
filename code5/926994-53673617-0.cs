     AVIWriter write = new AVIWriter();
        write.Open("newTestVideo.avi", Convert.ToInt32(320), Convert.ToInt32(240));
        Bitmap bit = new Bitmap(320,240);
        for (int tt = 0; tt < 240; tt++) {
            bit.SetPixel(tt, tt, System.Drawing.Color.FromArgb((int)(UnityEngine.Random.value*255f), (int)(UnityEngine.Random.value * 255f),(int)( UnityEngine.Random.value * 255f)));
            write.AddFrame(bit);
        }
        write.Close();
       
