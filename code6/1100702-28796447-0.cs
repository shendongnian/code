    public static unsafe Point GetPoint (Bitmap bmp, Color c) {
        BitmapData bmd = bmp.LockBits (new Rectangle(0,0,bmp.Width,bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        try {
            int s = bmd.Stride;
            int search = (c.A<<0x18)|(c.R<<0x10)|(c.G<<0x08)|c.B;
            int* clr = (int*)(void*)bmd.Scan0;
            int tmp;
            int* row = clr;
            for (int i = 0; i < bmp.Height; i++) {
                int* col = row;
                for (int j = 0; j < bmp.Width; j++) {
                    tmp = *col;
                    if(tmp == search) {
                        return new Point(j,i);
                    }
                    col++;
                }
                row += s>>0x02;
            }
            return new Point(-1,-1);
        } finally {
            bmp.UnlockBits (bmd);
        }
    }
