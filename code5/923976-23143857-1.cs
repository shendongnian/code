    public struct Rect
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
        public override string ToString()
        {
            return String.Format("left = {0}, top = {1}, right = {2}, bottom = {3}",
                Left, Top, Right, Bottom);
        }
    }
