    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))  // left click
            RevealTile();
        if(Input.GetMouseButtonDown(1))  // right click
            FlagTile();
    }
