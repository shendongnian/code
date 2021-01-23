    public partial class MainWindow : Window
    {
        private WriteableBitmap mImage;
        private CancellationTokenSource mShutdown;
        private object mUpdateLock = new object();
        private IntPtr mBuffer;
        private int mStride;
        public MainWindow()
        {
            InitializeComponent();
            mImage = new WriteableBitmap(10, 2, 96, 96, PixelFormats.Bgr32, null);
            wImage.Source = mImage;
            mShutdown = new CancellationTokenSource();
            Closed += delegate {
                // yeah that shutdown code is not great and can be improved
                mShutdown.Cancel();
                lock (mUpdateLock)
                    mImage.Unlock();
                CompositionTarget.Rendering -= CompositionTarget_Rendering;
            };
            mBuffer = mImage.BackBuffer;
            mStride = mImage.BackBufferStride;
            mImage.Lock();
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            UpdateAsync();
        }
        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            lock (mUpdateLock)
            {
                // for a large image you can optimize that by only updating the parts that changed,
                // collect dirty-areas in a list or something (while under the lock of course!)
                mImage.AddDirtyRect(new Int32Rect(0, 0, 10, 2));
                mImage.Unlock();
                mImage.Lock();
            }
        }
        private async void UpdateAsync()
        {
            int x = 0;
            int y = 0;
            int color = 0xFF0000;
            while (!mShutdown.IsCancellationRequested)
            {
                lock (mUpdateLock)
                {
                    // feel free to do 'unsafe' code here if you know what you're doing
                    Marshal.WriteInt32(new IntPtr(mBuffer.ToInt64() + x * 4 + y * mStride), color);
                }
                if (++x == 10)
                {
                    x = 0;
                    if (++y == 2)
                    {
                        y = 0;
                        color ^= 0xFF00FF;
                    }
                }
                await Task.Delay(500).ConfigureAwait(false);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(2000);
        }
    }
