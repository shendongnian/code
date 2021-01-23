    <Window.Resources>
            <Color x:Key="OverColor">Blue</Color>
            <Color x:Key="PressedColor">Green</Color>
        </Window.Resources>
        <Grid>
            <Button Content="Hi sheridan!" HorizontalAlignment="Center" VerticalAlignment="Center">
                <Button.Style>
                    <Style TargetType="{x:Type Button}">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type Button}">
                                    <Border Background="LightBlue">
                                        <VisualStateManager.VisualStateGroups>
                                            <VisualStateGroup x:Name="CommonStates">
                                                <VisualStateGroup.Transitions>
                                                    <VisualTransition GeneratedDuration="0:0:0.2"/>
                                                </VisualStateGroup.Transitions>
                                                <VisualState x:Name="Normal"/>
                                                <VisualState x:Name="Pressed">
                                                    <Storyboard>
                                                        <ColorAnimation Storyboard.TargetProperty="(Background).(SolidColorBrush.Color)" 
                                                                        To="{StaticResource PressedColor}"/>
                                                    </Storyboard>
                                                </VisualState>
                                                <VisualState x:Name="MouseOver">
                                                    <Storyboard>
                                                    <ColorAnimation Storyboard.TargetProperty="(Background).(SolidColorBrush.Color)" 
                                                                    To="{StaticResource OverColor}"/>
                                                    </Storyboard>
                                                </VisualState>
                                            </VisualStateGroup>
                                        </VisualStateManager.VisualStateGroups>
    
                                        <ContentPresenter Content="{TemplateBinding Content}"/>
                                    </Border>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </Button.Style>
            </Button>
        </Grid>
