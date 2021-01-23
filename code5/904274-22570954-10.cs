     using GameObjects;
     namespace WindowsGameHelp2
     {
        public class Sprite
        {
            public GameSprite Data { get; private set; }
            public Texture2D Texture { get; private set; }
            public Sprite(string path, ContentManager content)
            {
                Data = content.Load<GameSprite>(path);
                Texture = content.Load<Texture2D>(Data.TexturePath);
            }
            public void Draw(SpriteBatch sprite_batch)
            {
                sprite_batch.Draw(Texture, Data.Position, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
            }
        }
    }
