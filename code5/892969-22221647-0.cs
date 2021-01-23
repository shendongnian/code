    void Start() {
      GameObject go = new GameObject();
      Rect r = new Rect(0, 0, 100, 100); // the size
      go.AddComponent(new GUITexture().GetType());
      go.guiTexture.pixelInset = r;
      go.guiTexture.texture = (Texture2D)Resources.Load("graphics_name"); // must be placed in Assets/Textures/UI/Resources
      go.layer = LayerMask.NameToLayer("GUI Layer");
      go.transform.position = new Vector3(0, 0, 24);
      go.transform.localScale = new Vector3(0, 0, 1);
      go.name = "some name";
    }
