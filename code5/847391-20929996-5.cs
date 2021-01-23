    using System.Windows.Forms;
    
    namespace WpfWinformsTest
    {
        public partial class VideoStream : UserControl
        {
            AxWMPLib.AxWindowsMediaPlayer axVideoPlayer;
    
            public VideoStream()
            {
                InitializeComponent();
    
                this.axVideoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
                this.axVideoPlayer.Size = new System.Drawing.Size(200, 100);
                this.Controls.Add(this.axVideoPlayer);
            }
        }
    }
