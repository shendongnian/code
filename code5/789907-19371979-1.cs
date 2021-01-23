        public Game()
        {
            InitializeComponent();
            this.Loaded += Game_Loaded;
        }
        void Game_Loaded(object sender, RoutedEventArgs e)
        {
            SetGame();
            TouchPanel.EnabledGestures = GestureType.Tap;
            LayoutRoot.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(LayoutRoot_ManipulationCompleted);
        }
        void LayoutRoot_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                switch (gesture.GestureType)
                {
                    case GestureType.Tap:
                        Dispatcher.BeginInvoke(() => MoveLittleMan(gesture.Position));
                        break;
                }
            }
        }
        private void SetGame()
        {
            ScreenWidth = Application.Current.Host.Content.ActualWidth;
            ScreenHeight = Application.Current.Host.Content.ActualHeight;
            // littleman image is in 20 * 20
            littleManWidth = 20;
            littleManHeight = 20; 
            manLocY = (ScreenHeight / 2) + littleManHeight; //vert
            manLocX = (ScreenWidth / 2) + littleManWidth; //hori
            littleMan.Margin = new Thickness(manLocX, manLocY, 0, 0);
            leftControlArea = (ScreenWidth / 2);
            rightControlArea = (ScreenWidth / 2); // answer to the screen width;
            topControlArea = (ScreenHeight / 3);
            bottomControlArea = (ScreenHeight / 3) * 2; // answer to the screen height
        }
        private void MoveLittleMan(Vector2 tappedWhere)
        {
            double tapX, tapY;
            tapX = tappedWhere.X; // represent where user tapped on screen width wise
            tapY = tappedWhere.Y; // represent where user tapped on screen height wise
            if(tapY <= topControlArea)
            {
                // move top
                Debug.WriteLine("Move TOP - X: " + tapX + " - Y: " + tapY);
                if (manLocY > littleManHeight)
                {
                    manLocY = manLocY - skippingSteps;
                    littleMan.Margin = new Thickness(manLocX, manLocY, 0, 0);
                }
            }
            else if(tapY >= bottomControlArea)
            {
                //move bottom
                Debug.WriteLine("Move BOTTOM - X: " + tapX + " - Y: " + tapY);
                if (manLocY < (ScreenHeight - littleManHeight -50))
                {
                    manLocY = manLocY + skippingSteps;
                    littleMan.Margin = new Thickness(manLocX, manLocY, 0, 0);
                }
            }
            else if (tapX <= leftControlArea && tapY > topControlArea && tapY < bottomControlArea)
            { 
                //move left
                Debug.WriteLine("Move LEFT - X: " + tapX + " - Y: " + tapY);
                if (manLocX > littleManWidth)
                {
                    manLocX = manLocX - skippingSteps;
                    littleMan.Margin = new Thickness(manLocX, manLocY, 0, 0);
                }
            }
            else if (tapX > rightControlArea && tapY > topControlArea && tapY < bottomControlArea)
            { 
                //move right
                Debug.WriteLine("Move RIGHT - X: " + tapX + " - Y: " + tapY);
                if (manLocX < (ScreenWidth - littleManWidth))
                {
                    manLocX = manLocX + skippingSteps;
                    littleMan.Margin = new Thickness(manLocX, manLocY, 0, 0);
                }
            }
        }
