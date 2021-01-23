    using Awesomium.Core;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace AwesomiumComponent
    {
        public class BasicAwesomiumComponent : DrawableGameComponent
        {
            private Byte[] imageBytes;
            private Rectangle area;
            private Rectangle? newArea;
            private Boolean resizing;
            private SpriteBatch spriteBatch;
            private Texture2D WebViewTexture { get; set; }
            private SynchronizationContext awesomiumContext = null;
            private WebView WebView { get; set; }
            private BitmapSurface Surface { get; set; }
            private MouseState lastMouseState;
            private MouseState currentMouseState;
            private Keys[] lastPressedKeys;
            private Keys[] currentPressedKeys = new Keys[0];
            private static ManualResetEvent awesomiumReady = new ManualResetEvent(false);
            public Rectangle Area
            {
                get { return this.area; }
                set
                {
                    this.newArea = value;
                }
            }
    
            public BasicAwesomiumComponent(Game game, Rectangle area)
                : base(game)
            {
                this.area = area;
    
                this.spriteBatch = new SpriteBatch(game.GraphicsDevice);
    
                
                Thread awesomiumThread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    WebCore.Started += (s, e) => {
                        awesomiumContext = SynchronizationContext.Current;
                        awesomiumReady.Set();
                    };
                    
                    WebCore.Run();
                }));
    
                awesomiumThread.Start();
    
                WebCore.Initialize(new WebConfig() { });
    
                awesomiumReady.WaitOne();
    
                awesomiumContext.Post(state =>
                {
                    this.WebView = WebCore.CreateWebView(this.area.Width, this.area.Height, WebViewType.Offscreen);
    
                    this.WebView.IsTransparent = true;
                    this.WebView.CreateSurface += (s, e) =>
                    {
                        this.Surface = new BitmapSurface(this.area.Width, this.area.Height);
                        e.Surface = this.Surface;
                    };
                }, null);
            }
    
            public void SetResourceInterceptor(IResourceInterceptor interceptor)
            {
                awesomiumContext.Post(state =>
                {
                    WebCore.ResourceInterceptor = interceptor;
                }, null);
            }
    
            public void Execute(string method, params object[] args)
            {
                string script = string.Format("viewModel.{0}({1})", method, string.Join(",", args.Select(x => "\"" + x.ToString() + "\"")));
                this.WebView.ExecuteJavascript(script);
            }
    
            public void RegisterFunction(string methodName, Action<object, CancelEventArgs> handler)
            {
                // Create and acquire a Global Javascript object.
                // These object persist for the lifetime of the web-view.
                using (JSObject myGlobalObject = this.WebView.CreateGlobalJavascriptObject("game"))
                {
                    // The handler is of type JavascriptMethodEventHandler. Here we define it
                    // using a lambda expression.
    
                    myGlobalObject.Bind(methodName, true, (s, e) =>
                    {
                        handler(s, e);
                        // Provide a response.
                        e.Result = "My response";
                    });
                }
            }
    
            public void Load()
            {
                LoadContent();
            }
    
            protected override void LoadContent()
            {
                if (this.area.IsEmpty)
                {
                    this.area = this.GraphicsDevice.Viewport.Bounds;
                    this.newArea = this.GraphicsDevice.Viewport.Bounds;
                }
                this.WebViewTexture = new Texture2D(this.Game.GraphicsDevice, this.area.Width, this.area.Height, false, SurfaceFormat.Color);
    
                this.imageBytes = new Byte[this.area.Width * 4 * this.area.Height];
            }
    
            public override void Update(GameTime gameTime)
            {
                awesomiumContext.Post(state =>
                {
                    if (this.newArea.HasValue && !this.resizing && gameTime.TotalGameTime.TotalSeconds > 0.10f)
                    {
                        this.area = this.newArea.Value;
                        if (this.area.IsEmpty)
                            this.area = this.GraphicsDevice.Viewport.Bounds;
    
                        this.WebView.Resize(this.area.Width, this.area.Height);
                        this.WebViewTexture = new Texture2D(this.Game.GraphicsDevice, this.area.Width, this.area.Height, false, SurfaceFormat.Color);
                        this.imageBytes = new Byte[this.area.Width * 4 * this.area.Height];
                        this.resizing = true;
    
                        this.newArea = null;
                    }
    
                    lastMouseState = currentMouseState;
                    currentMouseState = Mouse.GetState();
    
                    this.WebView.InjectMouseMove(currentMouseState.X - this.area.X, currentMouseState.Y - this.area.Y);
    
                    if (currentMouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                    {
                        this.WebView.InjectMouseDown(MouseButton.Left);
                    }
                    if (currentMouseState.LeftButton == ButtonState.Released && lastMouseState.LeftButton == ButtonState.Pressed)
                    {
                        this.WebView.InjectMouseUp(MouseButton.Left);
                    }
                    if (currentMouseState.RightButton == ButtonState.Pressed && lastMouseState.RightButton == ButtonState.Released)
                    {
                        this.WebView.InjectMouseDown(MouseButton.Right);
                    }
                    if (currentMouseState.RightButton == ButtonState.Released && lastMouseState.RightButton == ButtonState.Pressed)
                    {
                        this.WebView.InjectMouseUp(MouseButton.Right);
                    }
                    if (currentMouseState.MiddleButton == ButtonState.Pressed && lastMouseState.MiddleButton == ButtonState.Released)
                    {
                        this.WebView.InjectMouseDown(MouseButton.Middle);
                    }
                    if (currentMouseState.MiddleButton == ButtonState.Released && lastMouseState.MiddleButton == ButtonState.Pressed)
                    {
                        this.WebView.InjectMouseUp(MouseButton.Middle);
                    }
    
                    if (currentMouseState.ScrollWheelValue != lastMouseState.ScrollWheelValue)
                    {
                        this.WebView.InjectMouseWheel((currentMouseState.ScrollWheelValue - lastMouseState.ScrollWheelValue), 0);
                    }
    
                    lastPressedKeys = currentPressedKeys;
                    currentPressedKeys = Keyboard.GetState().GetPressedKeys();
    
                    // Key Down
                    foreach (var key in currentPressedKeys)
                    {
                        if (!lastPressedKeys.Contains(key))
                        {
                            this.WebView.InjectKeyboardEvent(new WebKeyboardEvent()
                            {
                                Type = WebKeyboardEventType.KeyDown,
                                VirtualKeyCode = (VirtualKey)(int)key,
                                NativeKeyCode = (int)key
                            });
    
                            if ((int)key >= 65 && (int)key <= 90)
                            {
                                this.WebView.InjectKeyboardEvent(new WebKeyboardEvent()
                                {
                                    Type = WebKeyboardEventType.Char,
                                    Text = key.ToString().ToLower()
                                });
                            }
                            else if (key == Keys.Space)
                            {
                                this.WebView.InjectKeyboardEvent(new WebKeyboardEvent()
                                {
                                    Type = WebKeyboardEventType.Char,
                                    Text = " "
                                });
                            }
                        }
                    }
    
                    // Key Up
                    foreach (var key in lastPressedKeys)
                    {
                        if (!currentPressedKeys.Contains(key))
                        {
                            this.WebView.InjectKeyboardEvent(new WebKeyboardEvent()
                            {
                                Type = WebKeyboardEventType.KeyUp,
                                VirtualKeyCode = (VirtualKey)(int)key,
                                NativeKeyCode = (int)key
                            });
                        }
                    }
    
                }, null);
    
                base.Update(gameTime);
            }
    
            public override void Draw(GameTime gameTime)
            {
                awesomiumContext.Post(state =>
                {
                    if (Surface != null && Surface.IsDirty && !resizing)
                    {
                        unsafe
                        {
                            // This part saves us from double copying everything.
                            fixed (Byte* imagePtr = this.imageBytes)
                            {
                                Surface.CopyTo((IntPtr)imagePtr, Surface.Width * 4, 4, true, false);
                            }
                        }
                        this.WebViewTexture.SetData(this.imageBytes);
                    }
                }, null);
    
                Vector2 pos = new Vector2(0, 0);
                spriteBatch.Begin();
                spriteBatch.Draw(this.WebViewTexture, pos, Color.White);
                spriteBatch.End();
                GraphicsDevice.Textures[0] = null;
    
                base.Draw(gameTime);
            }
    
            public Uri Source
            {
                get
                {
                    return this.WebView.Source;
                }
                set
                {
                    awesomiumContext.Post(state =>
                    {
                        this.WebView.Source = value;
                    }, null);
                }
            }
    
            public void Resize(int width, int height)
            {
                this.newArea = new Rectangle(0, 0, width, height); ;
            }
        }
    }
