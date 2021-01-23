    //Capture used for taking frames from webcam
    private Capture capture;
    //Frame image which was obtained and analysed by EmguCV
    private Image<Bgr,byte> frame;
    //Unity's Texture object which can be shown on UI
    private Texture2D cameraTex;
    //...
    if(frame!=null)
        frame.Dispose();
    frame = capture.QueryFrame();
    if (frame != null)
    {
        GameObject.Destroy(cameraTex);
        cameraTex = TextureConvert.ImageToTexture2D<Bgr, byte>(frame, true);
        Sprite.DestroyImmediate(CameraImageUI.GetComponent<UnityEngine.UI.Image>().sprite);
        CameraImageUI.sprite = Sprite.Create(cameraTex, new Rect(0, 0, cameraTex.width, cameraTex.height), new Vector2(0.5f, 0.5f));
    }
