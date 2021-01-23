    using Microsoft.Xna.Framework.Input.Touch;
    using Microsoft.Xna.Framework;
    
    public MainPage()
    {
       InitializeComponent();
       TouchPanel.EnabledGestures = GestureType.Tap;
       this.Tap += MainPage_Tap;
    }
    private void MainPage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
       GestureSample gesture = TouchPanel.ReadGesture();
       Vector2 vector = gesture.Position;
       int positionX = (int)vector.X;
       int positionY = (int)vector.Y;
    }
