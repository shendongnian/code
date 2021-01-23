    public Vector2 GetMouseCoords()
    {
        var screenCoords = Mouse.GetPosition(); // Or whatever it's called.
        var sceneCoords = screenCoords / Resolution.ScreenScale;
        return sceneCoords;
    }
