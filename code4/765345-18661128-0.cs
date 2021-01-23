    using System; 
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    
    namespace WindowsFormsApplication1
    {
      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
          tm.Tick += new System.EventHandler(DoSomethingWithKeyboardInput);
          this.Load += new System.EventHandler(Form1_Load);
          textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(textbox1_KeyDown);
          textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(textbox1_KeyDown);
        }
    
        private Timer tm = new Timer();
        private List<System.Windows.Forms.Keys> MovementKeys = new List<System.Windows.Forms.Keys>();
        private _MyInputKeys MyInputKeys = new _MyInputKeys();
    
        private struct _MyInputKeys
        {
          public bool Jump;
          public bool Left;
          public bool Right;
        }
    
        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
          tm.Stop();
        }
    
        public void DoSomethingWithKeyboardInput(object sender, EventArgs e)
        {
          textBox1.Text = (MyInputKeys.Left ? "(left)" : "") + 
            (MyInputKeys.Right ? "(right)" : "") + (MyInputKeys.Jump ? "(jump)" : "");
        }
    
        private void Form1_Load(object sender, System.EventArgs e)
        {
          //define keys used for movement
    
          MovementKeys.Add(Keys.Up); //Jump ?
          MovementKeys.Add(Keys.Left); //Left Arrow - Move Left
          MovementKeys.Add(Keys.Right); //Rigth Arrow - Move Right
          tm.Interval = 50;
          tm.Start();
        }
    
        private void textbox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
          if (MovementKeys.IndexOf(e.KeyCode) != -1)
          {
            e.Handled = true;
            MyInputKeys.Jump = IsKeyDown(Keys.Up);
            MyInputKeys.Left = IsKeyDown(Keys.Left);
            MyInputKeys.Right = IsKeyDown(Keys.Right);
          }
        }
    
        public static bool IsKeyDown(Keys key)
        {
          return (GetKeyState(Convert.ToInt16(key)) & 0X80) == 0X80;
        }
        /// <summary>
        ///  If the high-order bit is 1, the key is down; otherwise, it is up.
        ///  If the low-order bit is 1, the key is toggled. 
        ///  A key, such as the CAPS LOCK key, is toggled if it is turned on. 
        ///  The key is off and untoggled if the low-order bit is 0. 
        ///  A toggle key's indicator light (if any) on the keyboard will be on when 
        ///  the key is toggled, and off when the key is untoggled.
        /// </summary>
        /// <param name="nVirtKey"></param>
        [DllImport("user32.dll")]
        public extern static Int16 GetKeyState(Int16 nVirtKey);
      }
    }
