    public static class Extensions {
        public static void ToPoint(this Vector2 vector) {
            return new Point((int)vector.X, (int)vector.Y);
        }
    }
    //Usage:
    Vector2 foo = new Vector2(5.2f);//X = 5.2f Y = 5.2F
    Point red = foo.ToPoint();
