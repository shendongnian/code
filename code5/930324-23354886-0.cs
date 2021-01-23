    <Grid StackPanel.MouseDown="StackPanel_MouseDown">
        <StackPanel Margin="70" Background="DarkGray" MouseDown="StackPanel_MouseDown">
            <TextBlock x:Name="XTextBlock"></TextBlock>
        </StackPanel>
    </Grid>
     private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender.GetType().Name.Equals("StackPanel"))
            {
                XTextBlock.Text = "I am direct raised from StackPanel.";
            }
            else //sender.GetType().Name.Equals("Grid")
            {
                XTextBlock.Text += "I am bubble raised from Grid.";
            }
        }
