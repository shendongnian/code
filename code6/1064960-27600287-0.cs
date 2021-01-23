    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Mp3Player
    {
        public partial class MediaPlayer : Form
        {
            string HomeDir;
            string[] sPlaylists, sURLs;
            List<string> listURLPlayers = new List<string>();
            public MediaPlayer()
            {
                InitializeComponent();
                HomeDir = Directory.GetCurrentDirectory();
                string[] playlist = File.ReadAllLines("playlist.txt");
                foreach (string fileText in playlist)
                {
                    listAudio.Items.Add(fileText);
                }
                string[] playlistUrl = File.ReadAllLines("playlistURL.txt");
                foreach (string fileText in playlistUrl)
                {
                    listURLPlayers.Add(fileText);
                }
            }
    
            private void btnOpen_Click(object sender, EventArgs e)
            {
                OpenFileDialog open = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    sPlaylists = openFileDialog1.SafeFileNames;
                    sURLs = openFileDialog1.FileNames;
                    for (int i = 0; i < sPlaylists.Length; i++)
                    {
                        listAudio.Items.Add(sPlaylists[i]);
                    }
                    for (int i = 0; i < sURLs.Length; i++)
                    {
                        listURLPlayers.Add(sURLs[i]);
                    }
                    System.IO.StreamWriter SaveFile = new System.IO.StreamWriter("playlist.txt");
                    foreach (var item in listAudio.Items)
                    {
                        SaveFile.WriteLine(item);
                    }
                    SaveFile.Close();
                    SaveFile = new System.IO.StreamWriter("playlistURL.txt");
                    foreach (var item in listURLPlayers)
                    {
                        SaveFile.WriteLine(item);
                    }
                    SaveFile.Close();
                }
            }
    
            private void listAudio_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                axWindowsMediaPlayer1.URL = listURLPlayers[listAudio.SelectedIndex];
            }
    
            private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
            {
                if (e.newState == 8)
                {
                    timer1.Enabled = true;
                }
            }
    
            private void listAudio_SelectedIndexChanged(object sender, EventArgs e)
            {
                axWindowsMediaPlayer1.URL = listURLPlayers[listAudio.SelectedIndex];
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                timer1.Enabled = false;
                Random rnd = new Random();
                int nowPlayIndex = rnd.Next(listURLPlayers.Count);
                axWindowsMediaPlayer1.URL = listURLPlayers[nowPlayIndex];
                listAudio.SelectedIndex = nowPlayIndex;
            }
        }
    }
