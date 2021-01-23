      <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition></ColumnDefinition>
            <ColumnDefinition></ColumnDefinition>
        </Grid.ColumnDefinitions>
        <StackPanel>
            <ListBox x:Name="lst">
                <ListBox.Triggers>
                    <EventTrigger RoutedEvent="GotFocus">
                        <BeginStoryboard>
                            <Storyboard>
                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="DeleteButton" Storyboard.TargetProperty="Visibility">
                                    <DiscreteObjectKeyFrame KeyTime="0:0:0.1" Value="{x:Static Visibility.Visible}"/>
                                </ObjectAnimationUsingKeyFrames>
                            </Storyboard> 
                        </BeginStoryboard>
                    </EventTrigger>
                    <EventTrigger RoutedEvent="LostFocus">
                        <BeginStoryboard>
                            <Storyboard>
                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="DeleteButton" Storyboard.TargetProperty="Visibility">
                                    <DiscreteObjectKeyFrame KeyTime="0:0:0.1" Value="{x:Static Visibility.Collapsed}"/>
                                </ObjectAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </ListBox.Triggers>
                <ListBoxItem>ListBoxItem1</ListBoxItem>
                <ListBoxItem>ListBoxItem2</ListBoxItem>
                <ListBoxItem>ListBoxItem3</ListBoxItem>
                <ListBoxItem>ListBoxItem4</ListBoxItem>
            </ListBox>
            <Button x:Name="DeleteButton"  Content="Delete" Height="30" Width="100">
                <Button.Style>
                    <Style  TargetType="Button">
                        <Setter Property="Visibility" Value="Visible"></Setter>
                        <Style.Triggers>                           
                            <DataTrigger Binding="{Binding Path=SelectedItem, ElementName=lst}" Value="{x:Null}" >
                                <Setter Property="Visibility" Value="Collapsed"></Setter>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </Button.Style>
            </Button>
        </StackPanel>
        
        <ListBox Grid.Column="1">
            <ListBoxItem>1</ListBoxItem>
            <ListBoxItem>2</ListBoxItem>
        </ListBox>
    </Grid>
