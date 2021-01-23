MainWindow.xaml
    <Window x:Class="StylesInteractivity.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"        
            xmlns:ie="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity" 
            xmlns:Core="clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions" 
            xmlns:int="clr-namespace:System.Windows.Interactivity" 
            xmlns:si="clr-namespace:StylesInteractivity"
            Title="MainWindow" Height="350" Width="525">
    
        <Window.Resources>
            <si:ViewModel x:Key="Model" />
        </Window.Resources>
    
        <Grid>      
            <Grid.ColumnDefinitions>
                <ColumnDefinition />
                <ColumnDefinition />
            </Grid.ColumnDefinitions>
        
            <TextBlock Grid.Column="1" x:Name="_tblock" 
                       Text="Default" 
                       HorizontalAlignment="Center" 
                       VerticalAlignment="Center" 
                       FontSize="24" 
                       FontWeight="Bold" />
        
            <ListBox ItemsSource="{Binding Source={StaticResource Model}, Path=DataSource}" 
                     Grid.Column="0"
                     HorizontalAlignment="Center" 
                     VerticalAlignment="Center">
            
                <ListBox.ItemContainerStyle>
                    <Style TargetType="ListBoxItem">
                        <Setter Property="FontSize" Value="24"/>
                        <Setter Property="FontWeight" Value="Bold"/>
                    
                        <Setter Property="int:InteractivityItems.Template">
                            <Setter.Value>
                                <int:InteractivityTemplate>
                                    <int:InteractivityItems>
                                        <int:InteractivityItems.Behaviors>
                                            <int:FlipOnHover />
                                        </int:InteractivityItems.Behaviors>
                                    
                                        <int:InteractivityItems.Triggers>
                                            <ie:EventTrigger EventName="MouseMove">
                                                <Core:ChangePropertyAction PropertyName="Text"
                                                                           TargetObject="{Binding ElementName=_tblock}"
                                                                           Value="{Binding}" />
                                            </ie:EventTrigger>
                                        </int:InteractivityItems.Triggers>
                                    </int:InteractivityItems>
                                </int:InteractivityTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </ListBox.ItemContainerStyle>
            </ListBox>
        </Grid>
    </Window>
InteractivityHelper.cs
    /// <summary>
    /// <see cref="FrameworkTemplate"/> for InteractivityElements instance
    /// <remarks>Subclassed for forward compatibility, perhaps one day <see cref="FrameworkTemplate"/> </remarks>
    /// <remarks>will not be partially internal</remarks>
    /// </summary>
    public class InteractivityTemplate : DataTemplate
    {
    }
    /// <summary>
    /// Holder for interactivity entries
    /// </summary>
    public class InteractivityItems : FrameworkElement
    {
        private List<Behavior> _behaviors;
        private List<TriggerBase> _triggers;
        /// <summary>
        /// Storage for triggers
        /// </summary>
        public List<TriggerBase> Triggers
        {
            get
            {
                if (_triggers == null)
                    _triggers = new List<TriggerBase>();
                return _triggers;
            }
        }
        /// <summary>
        /// Storage for Behaviors
        /// </summary>
        public List<Behavior> Behaviors
        {
            get
            {
                if (_behaviors == null)
                    _behaviors = new List<Behavior>();
                return _behaviors;
            }
        }
        #region Template attached property
        public static InteractivityTemplate GetTemplate(DependencyObject obj)
        {
            return (InteractivityTemplate)obj.GetValue(TemplateProperty);
        }
        public static void SetTemplate(DependencyObject obj, InteractivityTemplate value)
        {
            obj.SetValue(TemplateProperty, value);
        }
        public static readonly DependencyProperty TemplateProperty =
            DependencyProperty.RegisterAttached("Template", 
            typeof(InteractivityTemplate), 
            typeof(InteractivityItems),
            new PropertyMetadata(default(InteractivityTemplate), OnTemplateChanged));
        private static void OnTemplateChanged(
            DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            InteractivityTemplate dt = (InteractivityTemplate)e.NewValue;
    #if(!SILVERLIGHT)
            dt.Seal();
    #endif
            InteractivityItems ih = (InteractivityItems)dt.LoadContent();
            BehaviorCollection bc = Interaction.GetBehaviors(d);
            TriggerCollection tc = Interaction.GetTriggers(d);
            foreach (Behavior behavior in ih.Behaviors)
                bc.Add(behavior);
            foreach (TriggerBase trigger in ih.Triggers)
                tc.Add(trigger);
        }
        #endregion
    }
FlipOnHover.cs
    public class FlipOnHover : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
            AssociatedObject.MouseLeave += AssociatedObject_MouseLeave;
            Transform t = AssociatedObject.RenderTransform;
            AssociatedObject.RenderTransform = new TransformGroup();
            ((TransformGroup)AssociatedObject.RenderTransform).Children.Add(t);
            ((TransformGroup)AssociatedObject.RenderTransform).Children.Add(new ScaleTransform());
            base.OnAttached();
        }
        void AssociatedObject_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ((ScaleTransform)((TransformGroup)AssociatedObject.RenderTransform).Children[1]).ScaleY = 1;
        }
        void AssociatedObject_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ((ScaleTransform)((TransformGroup)AssociatedObject.RenderTransform).Children[1]).CenterX = AssociatedObject.ActualWidth / 2;
            ((ScaleTransform)((TransformGroup)AssociatedObject.RenderTransform).Children[1]).CenterY = AssociatedObject.ActualHeight / 2;
            ((ScaleTransform)((TransformGroup)AssociatedObject.RenderTransform).Children[1]).ScaleY=-1;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseEnter -= AssociatedObject_MouseEnter;
            AssociatedObject.MouseLeave -= AssociatedObject_MouseLeave;
        }
    }
ViewModel.cs
    public class ViewModel
    {
        private ObservableCollection<String> _dataSource = new ObservableCollection<string>();
        public ViewModel()
        {
            _dataSource.Add("Cat");
            _dataSource.Add("Dog");
            _dataSource.Add("Mouse");
            _dataSource.Add("Owl");
            _dataSource.Add("Rabbit");
        }
        public IEnumerable<string> DataSource
        {
            get { return _dataSource; }
        }
    }
