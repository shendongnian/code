    public partial class Form2 : Form
        {
            public Form1 MusicForm { get; set;}
            ...
            ...
    
     public partial class Form1 : Form
        {
            Form2 frm2 = new Form2();
            frm2.MusicForm = this;
            public WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
