Form1.cs
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.IO;
    using System.Windows.Forms;
    using System.Threading;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using System.Runtime.InteropServices;
    using System.Drawing;
    namespace XNATransparentWindow
    {
        public partial class Form1 : Form
        {
            private ContentBuilder contentBuilder;
            public Form1()
            {
                InitializeComponent();
                TopMost = true;
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            
                MARGINS margins = new MARGINS();
                margins.leftWidth = 0;
                margins.rightWidth = 0;
                margins.topHeight = this.Width;
                margins.bottomHeight = this.Height;
                // Extend aero glass style to whole form
                DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                //Load XNA directX
                this.contentBuilder = new ContentBuilder();
                graphicsDeviceService = GraphicsDeviceService.AddRef(Handle, ClientSize.Width, ClientSize.Height);
                //Register the service, so components like ContentManager can find it.
                services.AddService<IGraphicsDeviceService>(graphicsDeviceService);
                //Get the Graphics device
                dev = graphicsDeviceService.GraphicsDevice;
                if(dev == null){/*error message*/}
                //Load texture
                int bufferSize;
                System.IO.MemoryStream memoryStream;
                Bitmap img;
                using (img  = new Bitmap(@"C:\...\.png"))
                {
                    bufferSize = img.Height * img.Width * 4;
                
                    memoryStream = new System.IO.MemoryStream(bufferSize);
                    img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    texture = Texture2D.FromStream(dev, memoryStream, img.Width, img.Height, false);
                
                    memoryStream.Close();
                    if(texture == null){/*error message*/}
                }
            
                //Create sprite
                s_Batch = new SpriteBatch(dev);
                if(s_Batch == null){/*error message*/}
                FontPos = new Vector2(270.0F, 110.0F);
                //Load font
                contentManager = new ContentManager(services, this.contentBuilder.OutputDirectory);
                this.contentBuilder.Clear();
                this.contentBuilder.Add(@"C:\...\my_font1.spritefont","my_font1", "FontDescriptionImporter", "FontDescriptionProcessor");
                //Build spritefont to get the .xbn file
                string error = this.contentBuilder.Build();
                //If build fail
                if (!String.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error);
                    return;
                }
                //Load the .xbn file
                Font1 = contentManager.Load<SpriteFont>("my_font1");
                if(Font1 == null){/*error message*/}
            }
            [DllImport("dwmapi.dll")]
            static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margin);
            [DllImport("user32.dll")]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
            [StructLayout(LayoutKind.Sequential)]
            public struct MARGINS
            {
                public int leftWidth;
                public int rightWidth;
                public int topHeight;
                public int bottomHeight;
            }
            public ServiceContainer Services
            {
                get { return services; }
            }
            ServiceContainer services = new ServiceContainer();
            GraphicsDevice dev;
            SpriteFont Font1;
            Vector2 FontPos;
            SpriteBatch s_Batch;
            Texture2D texture;
            ContentManager contentManager;
            GraphicsDeviceService graphicsDeviceService;
            private const UInt32 WM_NCLBUTTONDOWN = 0xA1;
            private const Int32 HTCAPTION = 0x2;
            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.Close();
                }
                else //to move the form
                {
                    this.Capture = false;
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            }
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                //There are two buffers. One offscreen-backbuffer and the 
                //frontbuffer which is the actual form in this example. The
                //drawings are done to the backbuffer and in the end the two
                //buffers flip. The backbuffer becomes frontbuffer and the
                //frontbuffer becomes backbuffer.
                
                //The drawing should start when the last resource is loaded.
                //Since Font1 is the last one in this example I check for this
                if (Font1 == null)
                {
                    return;
                }
          
                //clear the backbuffer with transparent color.
                dev.Clear(Microsoft.Xna.Framework.Color.Transparent);
                //Do all your drawings here
                //draw texture and text with the sprite
                s_Batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
                s_Batch.Draw(texture, new Microsoft.Xna.Framework.Rectangle(0, 0, this.Width, this.Height), Microsoft.Xna.Framework.Color.White);
                s_Batch.DrawString(Font1, @"XNA FRAMEWORK", FontPos, Microsoft.Xna.Framework.Color.Black);
                s_Batch.End();
                //here the flip is performed
                dev.Present();
            }
            //Release resources
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                graphicsDeviceService.GraphicsDevice.Dispose();
                graphicsDeviceService.Release(true);
                s_Batch.Dispose();
                texture.Dispose();
            }
        }
    }
