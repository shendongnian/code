    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    namespace WindowsFormsApplication1 {
        public class ImageFormatter {
            public ImageFormatter() {
            }
            private const int MAX_LENGTH = 500;     // Constrain size to the longest edge
            private const int SHADOW_DEPTH = 30;    // This number has to be adjusted to taste 
                                                    // for each change in MAX_LENGTH
            private const double PIOver2 = Math.PI / 2.0;
            /// <summary>
            /// Creates a 3D representation of a 2D image, as if stretched around stretcher bars.
            /// </summary>
            public Image GetCanvasedImage(string srcImgPath) {
                Image src = SizeSourceImage(Bitmap.FromFile(srcImgPath));
                Bitmap output = new Bitmap(src, src.Width + (int)(src.Width * .125f), src.Height + (int)(src.Height * .125f));
                using (Bitmap side = new Bitmap((int)(src.Width * .10f), src.Height))
                using (GraphicsPath outline = new GraphicsPath())
                using (Graphics destGraphics = Graphics.FromImage(output)) {
                    // Set graphics options
                    destGraphics.Clear(Color.White);
                    destGraphics.InterpolationMode = InterpolationMode.Bicubic;
                    destGraphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    destGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Rectangle shadowRect = new Rectangle(
                        (int)(src.Width * .02),
                        (int)(src.Height * .03),
                        src.Width + (int)(src.Width * .07),
                        src.Height + (int)(src.Height * .03)
                    );
                    // Counter-clockwise points of front rectangle
                    Point[] destPoints = new Point[] { 
                            new Point(0, (int)(src.Height * .02f)), 
                            new Point(src.Width, 0), 
                            new Point(src.Width, src.Height),
                            new Point(0, src.Height - (int)(src.Height * .02f))
                        };
                    outline.AddPolygon(destPoints);
                    // Draw the drop shadow first
                    DrawRectangleDropShadow(
                        destGraphics,
                        shadowRect,
                        Color.FromArgb(25, 25, 25),
                        SHADOW_DEPTH,
                        128
                    );
                    // Draw front rectangle warped
                    destGraphics.DrawImage(ImageFormatter.Distort(
                        (Bitmap)src,
                        destPoints[0],
                        destPoints[1],
                        destPoints[3],
                        destPoints[2],
                        3
                    ), 0, 0);
                    // Create the inverted right-side graphic
                    src.RotateFlip(RotateFlipType.Rotate180FlipY);
                    using (Graphics sideGraphics = Graphics.FromImage(side)) {
                        sideGraphics.DrawImage(
                            src, 
                            new Rectangle(0, 0, side.Width, side.Height),
                            new Rectangle(new Point(0, 0), new Size(side.Width, side.Height)),
                            GraphicsUnit.Pixel);
                    }
                    destPoints = new Point[] { 
                        new Point(src.Width, 0), 
                        new Point(src.Width + (int)(side.Width * .5f), (int)(side.Height * .03f)), 
                        new Point(src.Width + (int)(side.Width * .5f), src.Height - (int)(side.Height * .03f)), 
                        new Point(src.Width, src.Height)
                    };
                    // Draw side rectangle warped
                    destGraphics.DrawImage(ImageFormatter.Distort(
                        (Bitmap)side,
                        destPoints[0],
                        destPoints[1],
                        destPoints[3],
                        destPoints[2],
                        3
                    ), 0, 0);
                    outline.AddPolygon(destPoints);
                    // Draw outline
                    GraphicsPath p = new GraphicsPath(FillMode.Alternate);
                    destGraphics.DrawPath(Pens.Black, outline);
                }
                return output;
            }
            /// <summary>
            /// Creates a matted representation of an image with accompanying drop shadow
            /// </summary>
            public Image GetMattedImage(string srcImgPath) {
            
                Image src = SizeSourceImage(Bitmap.FromFile(srcImgPath));
                int borderWidth = (int)(src.Width * .05f);
                Rectangle imageRect = new Rectangle(
                    0, 
                    0, 
                    src.Width + borderWidth * 2, 
                    src.Height + borderWidth * 2
                );
                Rectangle outputRect = new Rectangle(
                    0,
                    0,
                    src.Width + borderWidth * 2 + (int)(src.Height * .10f), 
                    src.Height + borderWidth * 2 + (int)(src.Height * .10f)
                );
                Rectangle shadowRect = imageRect;
                shadowRect.Inflate(8, 8);
                shadowRect.Offset(5, 5);
                Bitmap output = new Bitmap(outputRect.Width, outputRect.Height);
                using (GraphicsPath outline = new GraphicsPath())
                using (Graphics destGraphics = Graphics.FromImage(output)) {
                    // Set graphics options
                    destGraphics.Clear(Color.White);
                    destGraphics.InterpolationMode = InterpolationMode.Bicubic;
                    destGraphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    destGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    // Draw shadow
                    DrawRectangleDropShadow(
                        destGraphics,
                        shadowRect,
                        Color.FromArgb(25, 25, 25),
                        SHADOW_DEPTH,
                        128
                    );
                    // Draw image
                    destGraphics.FillRectangle(Brushes.White, imageRect);
                    destGraphics.DrawImage(src, borderWidth, borderWidth);
                    destGraphics.DrawRectangle(Pens.Black, imageRect);
                    // Draw outline
                    //destGraphics.DrawPath(Pens.Black, outline);
                }
                return output;
            }
            private Image SizeSourceImage(Image src) {
                int newWidth = 0;
                int newHeight = 0;
                if (src.Width >= src.Height) {
                    if (src.Width <= MAX_LENGTH)
                        return src;
                    double ratio = (double)src.Height / src.Width;
                    newWidth = MAX_LENGTH;
                    newHeight = (int)(MAX_LENGTH * ratio);
                }
                else {
                    if (src.Height <= MAX_LENGTH)
                        return src;
                    double ratio = (double)src.Width / src.Height;
                    newHeight = MAX_LENGTH;
                    newWidth = (int)(MAX_LENGTH * ratio);
                }
                double edgeWidth = newWidth * .05;
                Image resized = new Bitmap(src, new Size(newWidth, newHeight));
                Graphics g = Graphics.FromImage(resized);
                return new Bitmap(src, new Size(newWidth, newHeight));
            }
            private struct Vector {
                public PointF Origin;
                public float Direction;
                public Vector(PointF origin, float direction) {
                    this.Origin = origin;
                    this.Direction = direction;
                }
            }
            public static Bitmap Distort(Bitmap sourceBitmap, PointF topleft, PointF topright, PointF bottomleft, PointF bottomright) {
                return Distort(sourceBitmap, topleft, topright, bottomleft, bottomright, 2);
            }
            public static Bitmap Distort(Bitmap sourceBitmap, PointF topleft, PointF topright, PointF bottomleft, PointF bottomright, int interpolation = 0) {
                double sourceWidth = sourceBitmap.Width;
                double sourceHeight = sourceBitmap.Height;
                //Find dimensions of new image
                PointF[] pointarray = new PointF[] { topleft, topright, bottomright, bottomleft };
                int width = int.MinValue;
                int height = int.MinValue;
                foreach (PointF p in pointarray) {
                    width = (int)Math.Max(width, p.X);
                    height = (int)Math.Max(height, p.Y);
                }
                Bitmap bitmap = new Bitmap(width, height);
                //For faster image processing
                FastBitmap newBmp = new FastBitmap(bitmap);
                FastBitmap sourceBmp = new FastBitmap(sourceBitmap);
                newBmp.LockImage();
                sourceBmp.LockImage();
                //Key points
                PointF tl = (PointF)topleft;
                PointF tr = (PointF)topright;
                PointF br = (PointF)bottomright;
                PointF bl = (PointF)bottomleft;
                // sides
                float ab = GetAngle(tl, tr);
                float cd = GetAngle(br, bl);
                float ad = GetAngle(tl, bl);
                float bc = GetAngle(tr, br);
                //Get corner intersections
                PointF o = GetIntersection(new Vector(tr, ab), new Vector(br, cd));
                PointF n = GetIntersection(new Vector(tl, ad), new Vector(tr, bc));
                if (interpolation <= 0) 
                    interpolation = 1;
                int middleX = (int)(interpolation / 2.0);
                //Array of surronding pixels used for interpolation
                double[, ,] source = new double[interpolation, interpolation, 4];
                for (int y = 0; y < height; y++) {
                    for (int x = 0; x < width; x++) {
                        PointF P = new PointF(x, y);
                        float po = ab; //Default value
                        float pn = bc;
                        if (o != PointF.Empty) //If intersection found, get coefficient
                            po = GetAngle(o, P);
                        if (n != PointF.Empty) //If intersection found, get coefficient
                            pn = GetAngle(n, P);
                        //Get intersections
                        PointF l = GetIntersection(new Vector(P, po), new Vector(tl, ad));
                        if (l == PointF.Empty) 
                            l = tl;
                        PointF m = GetIntersection(new Vector(P, po), new Vector(br, bc));
                        if (m == PointF.Empty)
                            m = br;
                        PointF j = GetIntersection(new Vector(P, pn), new Vector(tr, ab));
                        if (j == PointF.Empty) 
                            j = tr;
                        PointF k = GetIntersection(new Vector(P, pn), new Vector(bl, cd));
                        if (k == PointF.Empty) 
                            k = bl;
                        double jp = GetDistance(j, P);
                        double lp = GetDistance(l, P);
                        double jk = GetDistance(j, k);
                        double lm = GetDistance(l, m);
                        //set direction
                        if (lm < GetDistance(m, P)) 
                            lp = -lp;
                        if (jk < GetDistance(k, P)) 
                            jp = -jp;
                        //interpolation
                        //find the pixels which surround the point
                        double yP0 = sourceHeight * jp / jk;
                        double xP0 = sourceWidth * lp / lm;
                        //top left coordinates of surrounding pixels
                        if (xP0 < 0) 
                            xP0--;
                        if (yP0 < 0) 
                            yP0--;
                        int left = (int)xP0;
                        int top = (int)yP0;
                        if ((left < -1 || left > sourceWidth) && (top < -1 || top > sourceHeight)) 
                            continue;
                        //weights
                        double xFrac = xP0 - (double)left;
                        double xFracRec = 1.0 - xFrac;
                        double yFrac = yP0 - (double)top;
                        double yFracRec = 1.0 - yFrac;
                        //get source pixel colors, or white if out of range (to interpolate into the background color)
                        int x0;
                        int y0;
                        Color color;
                        for (int sx = 0; sx < interpolation; sx++) {
                            for (int sy = 0; sy < interpolation; sy++) {
                                x0 = left + sx;
                                y0 = top + sy;
                                if (x0 > 0 && y0 > 0 &&
                                    x0 < sourceWidth && y0 < sourceHeight) {
                                    color = sourceBmp.GetPixel(x0, y0);
                                    source[sx, sy, 0] = color.R;
                                    source[sx, sy, 1] = color.G;
                                    source[sx, sy, 2] = color.B;
                                    source[sx, sy, 3] = 255.0f;
                                }
                                else {
                                    // set full transparency in this case
                                    source[sx, sy, 0] = 0;
                                    source[sx, sy, 1] = 0;
                                    source[sx, sy, 2] = 0;
                                    source[sx, sy, 3] = 0;
                                }
                            }
                        }
                        //interpolate on x
                        for (int sy = 0; sy < interpolation; sy++) {
                            //check transparency
                            if (source[middleX, sy, 3] != 0 && source[0, sy, 3] == 0) {
                                //copy colors from 1, sy
                                source[0, sy, 0] = source[1, sy, 0];
                                source[0, sy, 1] = source[1, sy, 1];
                                source[0, sy, 2] = source[1, sy, 2];
                                source[0, sy, 3] = source[1, sy, 3];
                            }
                            else {
                                //compute colors by interpolation
                                source[0, sy, 0] = source[0, sy, 0] * xFracRec + source[middleX, sy, 0] * xFrac;
                                source[0, sy, 1] = source[0, sy, 1] * xFracRec + source[middleX, sy, 1] * xFrac;
                                source[0, sy, 2] = source[0, sy, 2] * xFracRec + source[middleX, sy, 2] * xFrac;
                                source[0, sy, 3] = source[0, sy, 3] * xFracRec + source[middleX, sy, 3] * xFrac;
                            }
                            //interpolate transparency
                            source[0, sy, 3] = source[0, sy, 3] * xFracRec + source[middleX, sy, 3] * xFrac;
                        }
                        //now interpolate on y
                        //check transparency
                        if (source[0, middleX, 3] != 0 && source[0, 0, 3] == 0) {
                            //copy colors from 0, 1
                            source[0, 0, 0] = source[0, middleX, 0];
                            source[0, 0, 1] = source[0, middleX, 1];
                            source[0, 0, 2] = source[0, middleX, 2];
                            source[0, 0, 3] = source[0, middleX, 3];
                        }
                        else {
                            source[0, 0, 0] = source[0, 0, 0] * yFracRec + source[0, middleX, 0] * yFrac;
                            source[0, 0, 1] = source[0, 0, 1] * yFracRec + source[0, middleX, 1] * yFrac;
                            source[0, 0, 2] = source[0, 0, 2] * yFracRec + source[0, middleX, 2] * yFrac;
                            source[0, 0, 3] = source[0, 0, 3] * yFracRec + source[0, middleX, 3] * yFrac;
                        }
                        //interpolate transparency
                        source[0, 0, 3] = source[0, 0, 3] * yFracRec + source[0, middleX, 3] * yFrac;
                        //store to bitmap
                        if (source[0, 0, 3] != 0) //pixel has color
                            newBmp.SetPixel(x, y, Color.FromArgb((int)source[0, 0, 3], (int)source[0, 0, 0], (int)source[0, 0, 1], (int)source[0, 0, 2]));
                    }
                }
                sourceBmp.UnlockImage();
                newBmp.UnlockImage();
                return bitmap;
            }
            private static double GetDistance(PointF A, PointF B) {
                float a = A.X - B.X;
                float b = A.Y - B.Y;
                return Math.Sqrt((double)(a * a + b * b));
            }
            private static PointF GetIntersection(Vector vector1, Vector vector2) //Vector[] pointAngularCoeff)
            {
                if (vector1.Origin.X == vector2.Origin.X && vector1.Origin.Y == vector2.Origin.Y)
                    return vector1.Origin;
                if (vector1.Direction == vector2.Direction) return PointF.Empty; //Parallel, no intersection
                float newX = float.Epsilon;
                float newY = float.Epsilon;
                if (float.IsInfinity(vector1.Direction)) {
                    newX = vector1.Origin.X;
                    newY = vector2.Origin.Y + vector2.Direction * (-vector2.Origin.X + vector1.Origin.X);
                }
                if (float.IsInfinity(vector2.Direction)) {
                    newX = vector2.Origin.X;
                    newY = vector1.Origin.Y + vector1.Direction * (-vector1.Origin.X + vector2.Origin.X);
                }
                if (newX == float.Epsilon) {
                    float q1 = vector1.Origin.Y - vector1.Direction * vector1.Origin.X;
                    float q2 = vector2.Origin.Y - vector2.Direction * vector2.Origin.X;
                    newX = (q1 - q2) / (vector2.Direction - vector1.Direction);
                    newY = vector1.Direction * newX + q1;
                }
                if (float.IsInfinity(newX) || float.IsInfinity(newY))
                    return PointF.Empty; //no intersection found
                else {
                    return new PointF(newX, newY);
                }
            }
            private static float GetAngle(PointF from, PointF to) {
                double angle = GetAngleRad(from, to);
                double t = angle % Math.PI;
                if (Math.Abs(t - PIOver2) < 0.0000001) //t == PIOver2 (avoid loss of precision bug)
                {
                    return float.PositiveInfinity;
                }
                else {
                    if (Math.Abs(t + PIOver2) < 0.0000001) //t == -PIOver2 (avoid loss of precision bug)
                        return float.NegativeInfinity;
                    else
                        return (float)Math.Tan(angle);
                }
            }
            private static double GetAngleRad(PointF from, PointF to) {
                if (to.Y == from.Y) {
                    if (from.X > to.X)
                        return Math.PI;
                    else
                        return 0;
                }
                else if (to.X == from.X) {
                    if (to.Y < from.Y)
                        return -PIOver2;
                    else
                        return PIOver2;
                }
                else {
                    double m = Math.Atan(((to.Y - from.Y) / (to.X - from.X)));
                    if (to.X < 0)
                        if (m > 0)
                            return m + PIOver2;
                        else
                            return m - Math.PI;
                    else
                        return m;
                }
            }
            private static void DrawRectangleDropShadow(Graphics tg, Rectangle rc, Color shadowColor, int depth, int maxOpacity) {
                //calculate the opacities
                Color darkShadow = Color.FromArgb(maxOpacity, shadowColor);
                Color lightShadow = Color.FromArgb(0, shadowColor);
                //Create a shape for the path gradient brush
                using (GraphicsPath gp = new GraphicsPath()) 
                using (Bitmap patternbm = new Bitmap(2 * depth, 2 * depth))
                using (Graphics g = Graphics.FromImage(patternbm)) {
                    gp.AddEllipse(0, 0, 2 * depth, 2 * depth);
                    //Create the brush that will draw a softshadow circle
                    using (PathGradientBrush pgb = new PathGradientBrush(gp)) {
                        pgb.CenterColor = darkShadow;
                        pgb.SurroundColors = new Color[] { lightShadow };
                        g.FillEllipse(pgb, 0, 0, 2 * depth, 2 * depth);
                        SolidBrush sb = new SolidBrush(Color.FromArgb(maxOpacity, shadowColor));
                        tg.FillRectangle(sb, rc.Left + depth, rc.Top + depth, rc.Width - (2 * depth), rc.Height - (2 * depth));
                        sb.Dispose();
                        //top left corner
                        tg.DrawImage(patternbm, new Rectangle(rc.Left, rc.Top, depth, depth), 0, 0, depth, depth, GraphicsUnit.Pixel);
                        //top side
                        tg.DrawImage(patternbm, new Rectangle(rc.Left + depth, rc.Top, rc.Width - (2 * depth), depth), depth, 0, 1, depth, GraphicsUnit.Pixel);
                        //top right corner
                        tg.DrawImage(patternbm, new Rectangle(rc.Right - depth, rc.Top, depth, depth), depth, 0, depth, depth, GraphicsUnit.Pixel);
                        //right side
                        tg.DrawImage(patternbm, new Rectangle(rc.Right - depth, rc.Top + depth, depth, rc.Height - (2 * depth)), depth, depth, depth, 1, GraphicsUnit.Pixel);
                        //bottom left corner
                        tg.DrawImage(patternbm, new Rectangle(rc.Right - depth, rc.Bottom - depth, depth, depth), depth, depth, depth, depth, GraphicsUnit.Pixel);
                        //bottom side
                        tg.DrawImage(patternbm, new Rectangle(rc.Left + depth, rc.Bottom - depth, rc.Width - (2 * depth), depth), depth, depth, 1, depth, GraphicsUnit.Pixel);
                        //bottom left corner
                        tg.DrawImage(patternbm, new Rectangle(rc.Left, rc.Bottom - depth, depth, depth), 0, depth, depth, depth, GraphicsUnit.Pixel);
                        //left side
                        tg.DrawImage(patternbm, new Rectangle(rc.Left, rc.Top + depth, depth, rc.Height - (2 * depth)), 0, depth, depth, 1, GraphicsUnit.Pixel);
                    }
                }
            }
        }
        unsafe public class FastBitmap {
            public FastBitmap(Bitmap inputBitmap) {
                workingBitmap = inputBitmap;
            }
            private int width = 0;
            private Bitmap workingBitmap = null;
            private BitmapData bitmapData = null;
            private Byte* pBase = null;
            [StructLayout(LayoutKind.Sequential)]
            private struct PixelData {
                public byte blue;
                public byte green;
                public byte red;
                public byte alpha;
                public override string ToString() {
                    return "(" + alpha.ToString() + ", " + red.ToString() + ", " + green.ToString() + ", " + blue.ToString() + ")";
                }
            }
            public void LockImage() {
                //Size
                Rectangle bounds = new Rectangle(Point.Empty, workingBitmap.Size);
                width = (int)(bounds.Width * sizeof(PixelData));
                if (width % 4 != 0)
                    width = 4 * (width / 4 + 1);
                //Lock Image
                bitmapData = workingBitmap.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                pBase = (Byte*)bitmapData.Scan0.ToPointer();
            }
            private PixelData* pixelData = null;
            public Color GetPixel(int x, int y) {
                pixelData = (PixelData*)(pBase + y * width + x * sizeof(PixelData));
                return Color.FromArgb(pixelData->alpha, pixelData->red, pixelData->green, pixelData->blue);
            }
            public Color GetPixelNext() {
                pixelData++;
                return Color.FromArgb(pixelData->alpha, pixelData->red, pixelData->green, pixelData->blue);
            }
            public void SetPixel(int x, int y, Color color) {
                PixelData* data = (PixelData*)(pBase + y * width + x * sizeof(PixelData));
                data->alpha = color.A;
                data->green = color.G;
                data->blue = color.B;
                data->red = color.R;
            }
            public void UnlockImage() {
                workingBitmap.UnlockBits(bitmapData);
                bitmapData = null;
                pBase = null;
            }
        }
    }
