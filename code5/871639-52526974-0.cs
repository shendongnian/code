    ilssC                  = new ImageList();
    ilssC.ColorDepth       = System.Windows.Forms.ColorDepth.Depth16Bit;
    ilssC.ImageSize        = new System.Drawing.Size(200, 150);
    ilssC.TransparentColor = System.Drawing.Color.Transparent;
    Assembly myAssembly    = Assembly.GetExecutingAssembly();
    Stream myStream        = myAssembly.GetManifestResourceStream("SafeEnv.Resources.ssbars00.jpg");
    Bitmap bmp             = new Bitmap(myStream);
    ilssC.Images.Add         ("ssbars00.jpg",bmp);
    myStream               = myAssembly.GetManifestResourceStream("SafeEnv.Resources.ssbars01a.jpg");
    bmp                    = new Bitmap(myStream);
    ilssC.Images.Add         ("ssbars01a.jpg",bmp);
    myStream               = myAssembly.GetManifestResourceStream("SafeEnv.Resources.ssbars02a.jpg");
    bmp                    = new Bitmap(myStream);
    ilssC.Images.Add         ("ssbars02a.jpg", bmp);
    myStream               = myAssembly.GetManifestResourceStream("SafeEnv.Resources.ssbars03a.jpg");
    bmp                    = new Bitmap(myStream);
    ilssC.Images.Add         ("ssbars03a.jpg", bmp);
    myStream               = myAssembly.GetManifestResourceStream("SafeEnv.Resources.ssbars04a.jpg");
    bmp                    = new Bitmap(myStream);
    ilssC.Images.Add         ("ssbars04a.jpg", bmp);
    myStream               = myAssembly.GetManifestResourceStream("SafeEnv.Resources.ssbars05a.jpg");
    bmp                    = new Bitmap(myStream);
    ilssC.Images.Add         ("ssbars05a.jpg", bmp);
    ilssC.Images.SetKeyName  (0, "ssbars00.jpg");
    ilssC.Images.SetKeyName  (1, "ssbars01a.jpg");
    ilssC.Images.SetKeyName  (2, "ssbars02a.jpg");
    ilssC.Images.SetKeyName  (3, "ssbars03a.jpg");
    ilssC.Images.SetKeyName  (4, "ssbars04a.jpg");
    ilssC.Images.SetKeyName  (5, "ssbars05a.jpg");
