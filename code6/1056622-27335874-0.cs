    ...
    public Rectangle boundingBox;
    public meteorGenerator(Vector2 pos)
    {
        this.meteorPos = pos;
        this.boundingBox = new Rectangle((int)meteorPosPub.X, (int)meteorPosPub.Y, meteorTexture.Width, meteorTexture.Height);
    }
