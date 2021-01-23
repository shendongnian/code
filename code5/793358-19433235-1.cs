    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Input;
    
    namespace WinformExcercise1
    {
       public partial class Form1 : Form
       {
          private Dictionary<Keys, bool> keyIsDown = new Dictionary<Keys,bool>();
          private Timer timer;
          private int stream1;
    
          public Form1()
          {
             InitializeComponent();
             
             keyIsDown.Add(Keys.J, false);
             keyIsDown.Add(Keys.K, false);
             keyIsDown.Add(Keys.L, false);
    
             setupPlayer();
             this.KeyPreview = true;
          }
        
          private void setupPlayer()
          {
             // Bass.BASS_SetDevice(1);
             stream1 = Foo.GetStream2(path1.Text);
             // all code that is called once for setting things up goes here
          }
    
          private void Form1_KeyDown(object sender, KeyEventArgs e)
          {
             if (true == keyIsDown.ContainsKey(e.KeyCode))
             {
                keyIsDown[e.KeyCode] = true;
             }
             // do this for each key that you want to watch
          }
    
          private void Form1_KeyUp(object sender, KeyEventArgs e)
          {
             if (true == keyIsDown.ContainsKey(e.KeyCode))
             {
                keyIsDown[e.KeyCode] = false;
             }
             // do this for each key that you want to watch
          }
    
          private void Form1_Load(object sender, EventArgs e)
          {
             // This makes the computer constantly call the playKeys method
             timer = new Timer();
             timer.Interval = 1000;
             timer.Tick += new EventHandler(playKeys);
             timer.Enabled = true;
          }
    
          private void playKeys(Object source, EventArgs e)
          {
             // You have to add the next 8 lines once for each key you are watching
             // What I have here only does something for the J key.
             if (true == keyIsDown[Keys.J])
             {
                Bass.BASS_Init(1, 44100, BASSInit.BASS_DEVICE_DEFAULT, this.Handle);
             }
             else
             {
                Bass.BASS_StreamFree(Stream1);
             }
          }
    
    
       }
    }
