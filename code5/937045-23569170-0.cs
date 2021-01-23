    for (int i=0; i<objects.Count; i++)
    {
        GL.PushMatrix();
        objects[i].Render();
        GL.PopMatrix();
    }
    public void Render()
    {
        GL.Translate(Position);
        GL.Scale(Scale, Scale, Scale);
        ... draw primitives
    }
