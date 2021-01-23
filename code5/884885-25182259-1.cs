    public partial class MainForm : Form {
      IntPtr m_BitmapPtr;
      IntPtr m_CachedBitmapPtr = IntPtr.Zero;
      public MainForm() {
        InitializeComponent();
        Bitmap bitmap;
        using (var stream = typeof(MainForm).Assembly.GetManifestResourceStream("FormApplication.character.png")) {
          bitmap = (Bitmap)Bitmap.FromStream(stream);
        }
        unsafe {
          m_BitmapPtr = (IntPtr)BitmapUtility.GetBitmapPtrFromHICON((void*)bitmap.GetHicon());
        }
      }
      protected override void OnClosed(EventArgs e) {
        // TODO: refactor - dispose should happen in Dispose event
        unsafe {
          BitmapUtility.DisposeBitmap((void*)m_BitmapPtr);
          BitmapUtility.DisposeCachedBitmap((void*)m_CachedBitmapPtr);
        }
      }
      protected override void OnPaint(PaintEventArgs e) {
        var graphics = e.Graphics;
        IntPtr hdc;
        if (m_CachedBitmapPtr == IntPtr.Zero) {
          hdc = graphics.GetHdc();
          unsafe {
            m_CachedBitmapPtr = (IntPtr)BitmapUtility.CreateCachedBitmapPtr((void*)m_BitmapPtr, (void*)hdc);
          }
          graphics.ReleaseHdc(hdc);
        }
        hdc = graphics.GetHdc();
        unsafe {
          BitmapUtility.DrawCachedBitmap((void*)hdc, (void*)m_CachedBitmapPtr, 0, 0);
        }
        graphics.ReleaseHdc(hdc);
      }
    }
