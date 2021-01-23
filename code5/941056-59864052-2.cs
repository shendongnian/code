    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class PictureBoxCanvas
    {
        public uint[] Pixels { get; set; }
        Bitmap Bitmap { get; set; }
        GCHandle Handle { get; set; }
        IntPtr Addr { get; set; }
        bool IsRefreshing { get; set; }
        PictureBox PctCanvas { get; set; }
        public PictureBoxCanvas(PictureBox pctCanvas)
        {
            PctCanvas = pctCanvas;
            Reset();
        }
        public void Reset()
        {
            // Initialise resources
            Size ImageSize = new Size(320, 240); // This sets the resolution to 320 pixels wide and 240 pixels high. Modify this to any dimension you wish
            PixelFormat fmt = PixelFormat.Format32bppRgb;
            int PixelSize = Image.GetPixelFormatSize(fmt);
            int Step = ImageSize.Width * PixelSize;
            int padding = 32 - (Step % 32);
            if (padding < 32)
            {
                Step += padding;
            }
            Pixels = new uint[(Step / 32) * ImageSize.Height + 1];
            Handle = GCHandle.Alloc(Pixels, GCHandleType.Pinned);
            Addr = Marshal.UnsafeAddrOfPinnedArrayElement(Pixels, 0);
            Bitmap = new Bitmap(ImageSize.Width, ImageSize.Height, Step / 8, fmt, Addr);
            PctCanvas.Image = Bitmap;
        }
        public void Refresh()
        {
            // Update
            if (!IsRefreshing) // If computer is too slow then this will hold the next frame until the current one has finished
            {
                try
                {
                    IsRefreshing = true;
                    PctCanvas.Refresh();
                }
                catch //(Exception ex)
                {
                    //Console.Out.WriteLine(DateTime.Now.ToString("dd MMM yyyy HH:mm") + ":" + ex.Message + ex.StackTrace); // Uncomment to display exception info if desired
                }
                finally
                {
                    IsRefreshing = false;
                }
            }
        }
        public void Dispose()
        {
            // Finished so free up resources
            PctCanvas = null;
            Addr = IntPtr.Zero;
            if (Handle.IsAllocated)
            {
                Handle.Free();
            }
            Bitmap.Dispose();
            Bitmap = null;
            Pixels = null;
        }
    }
