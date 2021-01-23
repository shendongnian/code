        public static Icon toIcon(Bitmap b)
        {
            Bitmap cb = (Bitmap) b.Clone();
            cb.MakeTransparent(Color.White);
            System.IntPtr p = cb.GetHicon();
            Icon ico = Icon.FromHandle(p);
            return ico;
        }
