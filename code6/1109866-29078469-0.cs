    <Grid>
        <Grid.Resources>
            <Style TargetType="{x:Type CheckBox}">
                <EventSetter Event="Mouse.MouseEnter" Handler="Show_PopupToolTip" />
                <EventSetter Event="Mouse.MouseLeave" Handler="Hide_PopupToolTip"/>
            </Style>
        </Grid.Resources>
        <ContentControl>
            <StackPanel>
                <Popup Name="MyPopUp" Height="Auto" Width="Auto"  AllowsTransparency="True">
                    <Border BorderThickness="2" Background="Azure" BorderBrush="Black">
                        <StackPanel Margin="5">
                            <TextBlock Text="{Binding ElementName=CB, Path=ToolTip}" />
                        </StackPanel>
                    </Border>
                </Popup>
                <CheckBox Content="I am a check box" Name="CB" ToolTip="Some very long tooltip text here, it is really long" ToolTipService.IsEnabled="False">
                    
                </CheckBox> 
            </StackPanel>
        </ContentControl>
    </Grid>
     private void Show_PopupToolTip(object sender, MouseEventArgs e)
        {
            CheckBox cb = e.Source as CheckBox;
            MyPopUp.PlacementTarget = cb;
            MyPopUp.Placement = PlacementMode.MousePoint;
            MyPopUp.IsOpen = true;
            MyPopUp.StaysOpen = true;
        }
        private void Hide_PopupToolTip(object sender, MouseEventArgs e)
        {
            MyPopUp.IsOpen = false;  //comment this out if you want it to stay open until a click occurs
        }
