I figured out how to solve my problem. I decided not to use the Unloaded event to make the animation, but instead procedurally code the animation, then have the UserControl subscribe to the Completed event of that DoubleAnimation, and finally trigger its own delete event, which would make anything subscribed to *that* event occur (i.e. the removal from the visual  StackPanel and list of UserControl objects). This would allow the animation to run, and then, when it is finished, raise the deletion event.
Here's the mess of code for that. It's all pretty much summed up in these method calls. They're located within the UserControl:
    public static readonly RoutedEvent deleteEvent = EventManager.RegisterRoutedEvent("delete", RoutingStrategy.Bubble,
        typeof(RoutedEventHandler), typeof(TimeEntry));
     private TransformGroup animatedTransform;
     private ScaleTransform animatedScale;
     private DoubleAnimation deleteDoubleAnimation;
     public UserControl()//the constructor
     {
         timeIn = DateTime.Now;
         timeSpent = timeOut - timeIn;
         this.InitializeComponent();
         setUpRenderTransform();
         setUpAnimationVariables();
         deleteDoubleAnimation.Completed += deleteDoubleAnimation_Completed;
     }
    private void setUpRenderTransform()
    {
        animatedTransform = new TransformGroup();
        animatedScale = new ScaleTransform();
        animatedTransform.Children.Add(animatedScale);
        this.RenderTransform = animatedTransform;
    }
    private void setUpAnimationVariables()
    {
        deleteDoubleAnimation = new DoubleAnimation();
        deleteDoubleAnimation.To = 0;
        deleteDoubleAnimation.Duration = new Duration(TimeSpan.Parse("0:0:.25"));
    }
    private void raiseDeleteEvent()
    {
        RoutedEventArgs newDeleteEvent = new RoutedEventArgs(deleteEvent, this);
        RaiseEvent(newDeleteEvent);
    }
    private void deleteButton_Click(object sender, RoutedEventArgs e)
    {
        deleteAnimation();
    }
    void deleteDoubleAnimation_Completed(object sender, EventArgs e)
    {
        raiseDeleteEvent();
    }
    private void deleteAnimation()
    {
        animatedScale.BeginAnimation(ScaleTransform.ScaleXProperty, deleteDoubleAnimation);
        animatedScale.BeginAnimation(ScaleTransform.ScaleYProperty, deleteDoubleAnimation);
    }
