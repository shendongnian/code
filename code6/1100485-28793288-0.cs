    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Media;
    namespace play_Wav
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                SoundPlayer sp = new SoundPlayer(play_Wav.Properties.Resources.myFile);
                sp.Play();
            }
        }
    }
