    void Awake()
    {
        fullFilename = "http://585649.workwork.web.hostingtest.net/Images/Logo.png";
        disableButtons();
        StartCoroutine(Download());
        texTmp = new Texture2D(50, 50);
        spr = Sprite.Create(texTmp, new Rect(0, 0, texTmp.width, texTmp.height), Vector2.zero, 100);
        spr.texture.wrapMode = TextureWrapMode.Clamp;
        mat.mainTexture = spr.texture;
    }
    
    IEnumerator Download()
    {
        WWW www = new WWW(fullFilename);
        yield return www;
        www.LoadImageIntoTexture(texTmp);
        enableButtons();
    }
