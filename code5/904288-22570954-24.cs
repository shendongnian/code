    using GameObjects;
    namespace WindowsGameHelp2
    {
        public class Shop
        {
            private SpriteFont font;
    
            public FruitShop Data { get; private set; }
            public List<Texture2D> Texture { get; private set; }
            public Shop(string path, ContentManager content)
            {
                font = content.Load<SpriteFont>(@"Fonts\Default");
                Data = content.Load<FruitShop>(path);
                Texture = new List<Texture2D>();
                for (byte i = 0; i < Data.Fruits.Count; i++)
                    Texture.Add(content.Load<Texture2D>(Data.Fruits[i].TexturePath));
            }
            public void Draw(SpriteBatch sprite_batch)
            {
                for (byte i = 0; i < Data.Fruits.Count; i++)
                {
                    sprite_batch.Draw(Texture[i], Data.Fruits[i].Position, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
                    sprite_batch.DrawString(font, "|Name: " + Data.Fruits[i].Name + "|", Data.Fruits[i].Position + new Vector2(6, 128), Color.Black, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
                    for (byte x = 0; x < Data.Fruits[i].Nutrients.Length; x++)
                        sprite_batch.DrawString(font, "|Nutrient: " + Data.Fruits[i].Nutrients[x].ToString() + "|", Data.Fruits[i].Position + new Vector2(6, 128 + 20 * (x + 1)), Color.Black, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
                }
            }
        }
    }
