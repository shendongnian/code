    <ScrollViewer VerticalScrollBarVisibility="Hidden" HorizontalScrollBarVisibility="Hidden">
        <Grid>
            <Grid.Resources>
                <ResourceDictionary Source="../ResourceDictionary.xaml" />
            </Grid.Resources>
            <Grid.RowDefinitions>
                <RowDefinition Height="300" />
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="450"></ColumnDefinition>
                <ColumnDefinition Width="200"></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <ScrollViewer HorizontalScrollBarVisibility="Auto" Grid.Row="0" Grid.Column="0" Margin="10">
                <Grid>
                    <!--<Grid HorizontalAlignment="Left" Width="500">-->
                    <Grid.RowDefinitions>
                        <RowDefinition Height="40" />
                        <RowDefinition Height="110" />
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto" />
                    </Grid.ColumnDefinitions>
                    <Canvas x:Name="MyCanvasMarkers" Grid.Row="0" VerticalAlignment="Top" Grid.Column="0" />
                    <!-- this will always be the widest of the canvas's-->
                    <Canvas x:Name="MyCanvasShowEvents" Grid.Row="1" Grid.Column="0" />
                    <Canvas x:Name="MyCanvasFailEvents" Grid.Row="1" Grid.Column="0" />
                </Grid>
            </ScrollViewer>
            <!-- I doubt anything below this is useful for this post but I keep it in case I'm wrong-->
            <Grid x:Name="ConfigurationGrid" Grid.Column="1" Grid.Row="0">
                <StackPanel>
                    <Expander IsExpanded="True">
                        <Expander.Header>
                            <TextBlock Text="Zoom" />
                        </Expander.Header>
                        <Expander.Content>
                            <Border Style="{StaticResource LightBorder}">
                                <StackPanel>
                                    <TextBlock Text="Select Zoom Out Level" />
                                    <ComboBox ItemsSource="{Binding ScaleFactorOptions}"
                                              SelectedItem="{Binding SelectedScaleFactor, UpdateSourceTrigger=PropertyChanged}"
                                              HorizontalAlignment="Left"
                                              SelectionChanged="ZoomLevel_SelectionChanged">
                                        <ComboBox.Resources>
                                            <helper:ZoomConverter x:Key="ZoomConverter" />
                                        </ComboBox.Resources>
                                        <ComboBox.ItemTemplate>
                                            <DataTemplate>
                                                <TextBlock Text="{Binding Converter={StaticResource ZoomConverter}}" />
                                            </DataTemplate>
                                        </ComboBox.ItemTemplate>
                                    </ComboBox>
                                </StackPanel>
                            </Border>
                        </Expander.Content>
                    </Expander>
                    <Expander IsExpanded="True">
                        <Expander.Header>
                            <TextBlock Text="Time Period" />
                        </Expander.Header>
                        <Expander.Content>
                            <Border Style="{StaticResource LightBorder}">
                                <StackPanel>
                                    <TextBlock Text="Change Time Period" />
                                    <ComboBox ItemsSource="{Binding PeriodOptions}"
                                              SelectedItem="{Binding SelectedPeriod, UpdateSourceTrigger=PropertyChanged}"
                                              HorizontalAlignment="Left"
                                              SelectionChanged="TimePeriod_SelectionChanged">
                                    </ComboBox>
                                </StackPanel>
                            </Border>
                        </Expander.Content>
                    </Expander>
                    <Expander IsExpanded="True">
                        <Expander.Header>
                            <TextBlock Text="Properties" />
                        </Expander.Header>
                        <Expander.Content>
                            <Border Style="{StaticResource LightBorder}">
                                <StackPanel>
                                    <TextBlock x:Name="txtProperty" />
                                </StackPanel>
                            </Border>
                        </Expander.Content>
                    </Expander>
                </StackPanel>
            </Grid>
        </Grid>
    </ScrollViewer>
