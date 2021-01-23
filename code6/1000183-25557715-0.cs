        public virtual void Draw2D()
        {
            if (_2DList.Count > 0) { //pervents dividing by 0, and skips memory allocation if we have no Graphics
                Vector2 pos;
                float Z = 0; //to fight z-fighting, the sprites ar drawn in the order they were added.
                float step = 1.0f / _2DList.Count; //limiting the Z between [0..1]
                foreach (Graphic G in _2DList)
                {
                    if (G.visible())
                    {
                        pos = G.position();
                        Renderer.DrawHUDSprite(pos.X, pos.Y, Z, G.W(), G.H(), G.Texture());
                        Z += step; //with z starting at 0, it will never be 1.
                    }
                }
            }
        }
