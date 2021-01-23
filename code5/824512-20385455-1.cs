    <Page.DataContext>
        <local:MyViewModel/>
    </Page.DataContext>
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition Height="150" />
        </Grid.RowDefinitions>
        <FlipView ItemsSource="{Binding Colors}" SelectedItem="{Binding Selected, Mode=TwoWay}" UseTouchAnimationsForAllNavigation="{Binding ShowAnimations}">
            <FlipView.ItemTemplate>
                <DataTemplate>
                    <Rectangle>
                        <Rectangle.Fill>
                            <SolidColorBrush Color="{Binding Color}" />
                        </Rectangle.Fill>
                    </Rectangle>
                </DataTemplate>
            </FlipView.ItemTemplate>
        </FlipView>
        <ItemsControl ItemsSource="{Binding Colors}" Grid.Row="1" VerticalAlignment="Top" HorizontalAlignment="Center">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel Orientation="Horizontal" />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <Grid>
                            <Rectangle Height="100" Width="100" Margin="10">
                                <Rectangle.Fill>
                                    <SolidColorBrush Color="{Binding Color}" />
                                </Rectangle.Fill>
                                <Interactivity:Interaction.Behaviors>
                                    <Core:EventTriggerBehavior EventName="PointerPressed">
                                        <Core:CallMethodAction MethodName="SelectMe" TargetObject="{Binding}"/>
                                    </Core:EventTriggerBehavior>
                                </Interactivity:Interaction.Behaviors>
                            </Rectangle>
                            <TextBlock Text="X" VerticalAlignment="Top" HorizontalAlignment="Right" FontSize="50" Margin="20,10" Foreground="Wheat">
                                <Interactivity:Interaction.Behaviors>
                                    <Core:EventTriggerBehavior EventName="PointerPressed">
                                        <Core:CallMethodAction MethodName="RemoveMe" TargetObject="{Binding}"/>
                                    </Core:EventTriggerBehavior>
                                </Interactivity:Interaction.Behaviors>
                            </TextBlock>
                        </Grid>
                        <Rectangle Height="10" Width="100" Margin="10" 
                                   Fill="White" Visibility="{Binding Selected}" />
                    </StackPanel>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
