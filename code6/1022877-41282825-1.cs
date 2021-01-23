    internal static ScreenCapture Capture;
    if (Capture == null)
    {
        Capture = Camera.main.gameObject.AddComponent<ScreenCapture>();
    }
    Capture.SaveScreenshot();
    // if you wish to save:
    System.IO.File.WriteAllBytes("filename.png", Capture.Image);
