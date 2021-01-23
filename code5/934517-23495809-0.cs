    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                CommandBinding cmdBinding = new CommandBinding (Microsoft.Windows.Shell.SystemCommands.CloseWindowCommand,
                    CloseCommandHandler);
                this.CommandBindings.Add(cmdBinding);
            }
    
            private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
            {
                if (e.Parameter != null)
                {
                    (e.Parameter as Window).Close();
                }
            }
        }
    <Button x:Name="btn3" Command="shell:SystemCommands.CloseWindowCommand" CommandParameter="{Binding ElementName=myWindow}" ToolTip="close"  Style="{StaticResource WindowButtonStyle}">
                <Button.Content>
                    <Grid Width="30" Height="25" RenderTransform="1,0,0,1,0,1">
                        <Path Data="M0,0 L8,7 M8,0 L0,7 Z" Width="8" Height="7" VerticalAlignment="Center" HorizontalAlignment="Center"
                                                            Stroke="{Binding Foreground, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Button}}" StrokeThickness="1.5"  />
                    </Grid>
                </Button.Content>
            </Button>
