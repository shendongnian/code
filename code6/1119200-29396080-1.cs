    void OnMouseOver()
    {
        if(Input.GetMouseButtonUp(0))  // left click released
            RevealTile();
        if(Input.GetMouseButtonUp(1))  // right click released
            FlagTile();
    }
