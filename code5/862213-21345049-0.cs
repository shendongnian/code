    <Window x:Class="GamePadTest.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <TextBlock x:Name="TextBlock1"></TextBlock>
        </Grid>
    </Window>
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    
    namespace GamePadTest
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                CompositionTarget.Rendering += CompositionTarget_Rendering;
            }
    
            private void CompositionTarget_Rendering(object sender, EventArgs e)
            {
                var gamePadState = GamePad.GetState(PlayerIndex.One);
                TextBlock1.Text = gamePadState.ThumbSticks.Left.ToString();
            }
        }
    }
