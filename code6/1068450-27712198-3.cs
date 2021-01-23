        <Window.Resources>
            <Style TargetType="UserControl">
                <Setter Property="HorizontalContentAlignment" Value="Center" />
                <Setter Property="VerticalContentAlignment" Value="Center" />
                <Setter Property="Background" Value="#CCDDEE" />
                <Setter Property="Margin" Value="3" />
            </Style>
        </Window.Resources>
        <DockPanel>
            <Button DockPanel.Dock="Bottom" Margin="5" Content="Change Orientation"
                    Click="ChangeOrientation" />
        
            <ContentControl>
                <ContentControl.Style>
                    <Style TargetType="ContentControl">
                        <Setter Property="Content">
                            <Setter.Value>
                                <Grid>
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition />
                                        <ColumnDefinition />
                                    </Grid.ColumnDefinitions>
                                    <Grid.RowDefinitions>
                                        <RowDefinition />
                                        <RowDefinition />
                                    </Grid.RowDefinitions>
                                    <UserControl Content="Sub 1" />
                                    <UserControl Grid.Column="1" Content="Sub 2" />
                                    <UserControl Grid.Row="1" Grid.ColumnSpan="2" Content="Main" />
                                </Grid>
                            </Setter.Value>
                        </Setter>
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding IsLandscape}" Value="True">
                                <Setter Property="Content">
                                    <Setter.Value>
                                        <Grid>
                                            <Grid.ColumnDefinitions>
                                                <ColumnDefinition />
                                                <ColumnDefinition />
                                            </Grid.ColumnDefinitions>
                                            <Grid.RowDefinitions>
                                                <RowDefinition />
                                                <RowDefinition />
                                            </Grid.RowDefinitions>
                                            <UserControl Grid.Column="1" Content="Sub 1" />
                                            <UserControl Grid.Column="1" Grid.Row="1" Content="Sub 2" />
                                            <UserControl Grid.RowSpan="2" Content="Main" />
                                        </Grid>
                                    </Setter.Value>
                                </Setter>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </ContentControl.Style>
            </ContentControl>
        </DockPanel>
