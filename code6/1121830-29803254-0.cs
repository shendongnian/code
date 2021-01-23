    using Windows.UI.Core;
    using SharpDX.Toolkit;
    using Windows.System;
    namespace Example
    {
        class MyGame : Game
        {
            public MyGame()
            {
                CoreWindow.GetForCurrentThread().KeyDown += MyGame_KeyDown;
            }
            void MyGame_KeyDown(CoreWindow sender, KeyEventArgs args)
            {
                System.Diagnostics.Debug.WriteLine(args.VirtualKey);
            }
        }
    }
