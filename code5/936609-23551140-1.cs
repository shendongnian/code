    void Start()
    {
        // Initialize all textures to be inactive
        for(int i = 0; i < activateTexture.Count; i++)
        {
            activateTexture[i].SetActive(false);
        }
        // Activate the first texture
        activateTexture[0].SetActive(true);
    }
    // Store the index of the currently active texture
    private int activeTextureIndex = 0;
    void OnClick()
    {
        // Disable the current
        activateTexture[activeTextureIndex % activateTexture.Length].SetActive(false);
        
        // Increment the index
        activeTextureIndex++;
        // Activate a texture based upon the new index
        activateTexture[activeTextureIndex % activateTexture.Length].SetActive(true);
    }
