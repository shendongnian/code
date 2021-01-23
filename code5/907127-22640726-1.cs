    namespace Clase_25_3_2014
    {
        class Brick
        {
            public Brick(int speed, Vector2 position, Texture2D skin)
            {
                this.Speed = speed;
                this.Pos = position;
                this.Skin = skin;
            }
            public int Speed { get; set; }
            public Vector2 Pos { get; set; }
            public Texture2D Skin { get; set; }
        }
    }
