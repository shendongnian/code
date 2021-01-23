     public Vector2 position
     public Vector2 Position
     {
       get { return position }
       set { position = value; }
     }
    public meteorGenerator(Texture2D texture, Vector2 position)
    {
        Position = texture;
        Texture = position;
    }
