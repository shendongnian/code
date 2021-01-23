    public partial class AttributeStack : UserControl
    {
        #region Val (DependencyProperty)
        public string Val
        {
            get { return (string)GetValue(ValProperty); }
            set { SetValue(ValProperty, value); }
        }
        public static readonly DependencyProperty ValProperty =
            DependencyProperty.Register("Val", typeof(string), typeof(AttributeStack),
              new PropertyMetadata { PropertyChangedCallback = ValChanged });
        private static void ValChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AttributeStack aStack = d as AttributeStack;
            if (aStack != null && e.NewValue != null)
            {
                aStack.ValLabel.Content = e.NewValue.ToString();
            }
        }
        #endregion
        public static readonly DependencyProperty AttrProperty = DependencyProperty.Register
            (
                 "Attr",
                 typeof(string),
                 typeof(AttributeStack),
                 new PropertyMetadata(string.Empty)
            );
        public string Attr
        {
            get { return (string)GetValue(AttrProperty); }
            set { SetValue(AttrProperty, value); }
        }
        
        public AttributeStack()
        {
            InitializeComponent();
        }
    }
}
    public partial class SceneView : Page
    {
        public static readonly DependencyProperty sceneProperty = DependencyProperty.Register
            (
                 "scene",
                 typeof(Scene),
                 typeof(SceneView)
            );
        public Scene scene
        {
            get { return (Scene)GetValue(sceneProperty); }
            set { SetValue(sceneProperty, value); }
        }
        public SceneView(Scene s)
        {
            InitializeComponent();
            scene = s;
            
            this.DataContext = scene;
        }
    }
    <Page x:Class="Pipeline_General.SceneView" x:Name="page"
      xmlns:pm="clr-namespace:Pipeline_General"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
      xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
      mc:Ignorable="d" 
      xmlns:cc="clr-namespace:Pipeline_General.Custom_Controls"
      d:DesignHeight="800" d:DesignWidth="600"
      DataContext = "{Binding RelativeSource={RelativeSource Self}}"
	  Title="SceneView">
    <Grid>
        <ScrollViewer>
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*" />
                    <ColumnDefinition Width="*" />
                </Grid.ColumnDefinitions>
                <StackPanel Grid.Column="0">
                    <Expander IsExpanded="True" Margin="5">
                        <Expander.Header>
                            <Grid x:Name="Grid" HorizontalAlignment="Stretch" Width="NaN">
                                <Border x:Name="Border" Background="Transparent" HorizontalAlignment="Stretch" BorderBrush="{x:Static pm:myBrushes.blue}" BorderThickness="0,0,0,1"
                            Width="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type Expander}}, Path=ActualWidth}">
                                    <TextBlock x:Name="HeaderText" FontSize ="18" FontFamily="Calibri" Foreground="{x:Static pm:myBrushes.blue}" Text="General Info: " />
                                </Border>
                            </Grid>
                        </Expander.Header>
                        <StackPanel>
                            <Separator Foreground="Transparent" Height="0" Margin="5"/>
                            <cc:AttributeStack Attr="Title:" Val="{Binding Path=scene.Title, RelativeSource={RelativeSource Mode=FindAncestor,AncestorType=Page}}"/>
                            <Separator Foreground="Transparent" Height="0" Margin="5"/>
                            <cc:AttributeStack Attr="Episode:" Val="{Binding Path=scene.episode.Key, RelativeSource={RelativeSource Mode=FindAncestor,AncestorType=Page}}"/>
                            <cc:AttributeStack Attr="Sequence:" Val="{Binding Path=scene.sequence.Key, RelativeSource={RelativeSource Mode=FindAncestor,AncestorType=Page}}"/>
                            <cc:AttributeStack Attr="Scene:" Val="{Binding Path=scene.Key, RelativeSource={RelativeSource Mode=FindAncestor,AncestorType=Page}}"/>
                            <Separator Foreground="Transparent" Height="0" Margin="5"/>
                            <cc:AttributeStack Attr="Assigned:" Val="{}"/>
                            
                            <cc:AttributeStack Attr="Status:" Val="{Binding Path=Title, RelativeSource={RelativeSource Mode=FindAncestor,AncestorType=Page}}"/>
                            <Separator Foreground="Transparent" Height="0" Margin="5"/>
                            <cc:AttributeStack Attr="Last Saved (Time):" Val="{Binding Path=Title, RelativeSource={RelativeSource Mode=FindAncestor,AncestorType=Page}}"/>
                            <cc:AttributeStack Attr="Last Saved (User):" Val="{Binding Path=Title, RelativeSource={RelativeSource Mode=FindAncestor,AncestorType=Page}}"/>
                            <Separator Foreground="Transparent" Height="0" Margin="5"/>
                            <cc:AttributeStack Attr="Due:" Val="{Binding Path=Title, RelativeSource={RelativeSource Mode=FindAncestor,AncestorType=Page}}"/>
                        </StackPanel>
                    </Expander>
                </StackPanel>
                
                <StackPanel Grid.Column="1">
                    <cc:Playblast_Viewer  x:Name="PlayblastView"/>
                    <cc:FeedbackCtrl Header="Feedback"/>
                    <cc:FeedbackCtrl Header="NoticeBoard"/>
                </StackPanel>
               
            </Grid>
        </ScrollViewer>
    </Grid>
