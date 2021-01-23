    <controls:ImageControl   Source="{Binding CurrentImage}" >
                <controls:ImageControl.Triggers>
                    <EventTrigger RoutedEvent="controls:ImageControl.SourceChanged">
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetProperty="(Image.Opacity)" From="0" To="1" Duration="0:0:1" />
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </controls:ImageControl.Triggers>
            </controls:ImageControl>
    
    
      public class ImageControl : Image
        {
            public static readonly RoutedEvent SourceChangedEvent = EventManager.RegisterRoutedEvent(
          "SourceChanged", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(ImageControl));
    
            static ImageControl()
            {
                Image.SourceProperty.OverrideMetadata(typeof(ImageControl), new FrameworkPropertyMetadata(SourcePropertyChanged));
            }
    
            public event RoutedEventHandler SourceChanged
            {
                add { AddHandler(SourceChangedEvent, value); }
                remove { RemoveHandler(SourceChangedEvent, value); }
            }
    
            private static void SourcePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            {
                Image image = obj as Image;
                if (image != null)
                {
                    image.RaiseEvent(new RoutedEventArgs(SourceChangedEvent));
                }
            }
        }
