    <SolidColorBrush x:Key="iconBrush" Color="Red" />
    <SolidColorBrush x:Key="blueBrush" Color="Blue" />
    <Style x:Key="ImageTextButtonStyle" TargetType="{x:Type Button}">
        <Setter Property="Background" Value="{StaticResource iconBrush}" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Button}">
                    <Border>
                        <Grid>
                            <Grid.RowDefinitions>
                                <RowDefinition Height="20" />
                                <RowDefinition Height="10" />
                            </Grid.RowDefinitions>
                            <Grid Grid.Row="0">
                                <Grid.Background>
                                    <DrawingBrush Stretch="Uniform">
                                        <DrawingBrush.Drawing>
                                            <DrawingGroup>
                                                <DrawingGroup.Children>
                                                    <GeometryDrawing Brush="{Binding Background, RelativeSource={RelativeSource TemplatedParent}}" Geometry="..." />
                                                </DrawingGroup.Children>
                                            </DrawingGroup>
                                        </DrawingBrush.Drawing>
                                    </DrawingBrush>
                                </Grid.Background>
                            </Grid>
                            <Grid Grid.Row="1">
                                <ContentPresenter />
                            </Grid>
                        </Grid>
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Background" Value="{StaticResource blueBrush}" />
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
