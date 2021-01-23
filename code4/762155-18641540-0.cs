        public static bool TouchTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - 1 &&
                    r1.Bottom <= r2.Top + (r2.Height / 2) &&
                    r1.Right >= r2.Left &&
                    r1.Left <= r2.Right);
        }
        public static bool TouchBottomOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Top <= r2.Bottom + (r2.Height / 2) &&
                    r1.Top >= r2.Bottom - 1 &&
                    r1.Right >= r2.Left  &&
                    r1.Left <= r2.Right );
        }
        public static bool TouchLeftOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Right <= r2.Right &&
                    r1.Right >= r2.Left &&
                    r1.Top <= r2.Bottom &&
                    r1.Bottom >= r2.Top);
        }
        public static bool TouchRightOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Left &&
                    r1.Left <= r2.Right &&
                    r1.Top <= r2.Bottom &&
                    r1.Bottom >= r2.Top);
        }
