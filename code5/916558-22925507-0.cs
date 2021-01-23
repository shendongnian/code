        class GamePoint
        {
            public int x { get; set; }
            public int y { get; set; }
            public GamePoint(int x_, int y_) {x=x_; y= y_;}
            public static GamePoint operator +(GamePoint GamePoint1, GamePoint GamePoint2)
            {
                return new GamePoint(
                    GamePoint1.x + GamePoint2.x,
                    GamePoint2.y + GamePoint1.y);
            }
            public override string ToString()
            {
                return " (" + this.x.ToString() + "/" + this.y.ToString() + ") ";
            }
        }
