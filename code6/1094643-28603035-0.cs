    public Decal decal;
    public Material mat;
    Texture2D texTmp;
    Sprite spr;
    string settingsContent;
    string[] settingsSplit;
    int texWidth,texHeight;
    float sizeX, sizeY;
    void Awake()
    {
        StartCoroutine(DownloadSettings());
    }
    IEnumerator DownloadSettings()
    {
        WWW www = new WWW("http://sitesman.com/logotypes/Logo1/settings.txt");
        yield return www;
        settingsContent = www.text;
        settingsSplit = settingsContent.Split('\n');
        if (www.isDone)
        {
            texWidth = int.Parse(settingsSplit[1]);
            texHeight = int.Parse(settingsSplit[2]);
            texTmp = new Texture2D(texWidth,texHeight);
            if(texWidth > texHeight)
            {
                sizeX = texWidth / texHeight;
                sizeY = 1;
            }
            else if (texWidth < texHeight)
            {
                sizeX = 1;
                sizeY = texHeight / texWidth;
            }
            else
            {
                sizeX = 1;
                sizeY = 1;
            }
            float multipier = 1;
            if(settingsSplit[4] != null)
            {
                multipier = float.Parse(settingsSplit[4]);
            }
            decal.transform.localScale = new Vector3(sizeX*multipier,sizeY*multipier,2f);
            StartCoroutine(DownloadLogos());
        }
    }
    IEnumerator DownloadLogos()
    {
        WWW www = new WWW(settingsSplit[0]);
        yield return www;
        www.LoadImageIntoTexture(texTmp);
        if (www.isDone)
        {
            spr = Sprite.Create(texTmp, new Rect(0, 0, texTmp.width, texTmp.height), Vector2.zero, 100);
            spr.texture.wrapMode = TextureWrapMode.Clamp;
            mat.mainTexture = spr.texture;
            Color clr = new Color32(255,255,255,255);
            clr.a = float.Parse(settingsSplit[3]);
            mat.color = clr;
            decal.material = mat;
            decal.sprite = spr;
            BuildDecal(decal);
        }
    }
    GameObject go;
    private GameObject[] affectedObjects;
    private void BuildDecal(Decal decal)
    {
        MeshFilter filter = decal.GetComponent<MeshFilter>();
        if (filter == null) filter = decal.gameObject.AddComponent<MeshFilter>();
        if (decal.renderer == null) decal.gameObject.AddComponent<MeshRenderer>();
        decal.renderer.material = decal.material;
        if (decal.material == null || decal.sprite == null)
        {
            filter.mesh = null;
            return;
        }
        affectedObjects = GetAffectedObjects(decal.GetBounds(), decal.affectedLayers);
        foreach (GameObject go in affectedObjects)
        {
            DecalBuilder.BuildDecalForObject(decal, go);
        }
        DecalBuilder.Push(decal.pushDistance);
        Mesh mesh = DecalBuilder.CreateMesh();
        if (mesh != null)
        {
            mesh.name = "DecalMesh";
            filter.mesh = mesh;
        }
    }
    private static GameObject[] GetAffectedObjects(Bounds bounds, LayerMask affectedLayers)
    {
        MeshRenderer[] renderers = (MeshRenderer[])GameObject.FindObjectsOfType<MeshRenderer>();
        List<GameObject> objects = new List<GameObject>();
        foreach (Renderer r in renderers)
        {
            if (!r.enabled) continue;
           // if (!IsLayerContains(affectedLayers, r.gameObject.layer)) continue;
            if (r.GetComponent<Decal>() != null) continue;
            if (bounds.Intersects(r.bounds))
            {
                objects.Add(r.gameObject);
            }
        }
        return objects.ToArray();
    }
