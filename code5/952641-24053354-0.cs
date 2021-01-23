     <Color x:Key="ControlNormalColor">#FFFFFF</Color>
        <Color x:Key="ControlMouseOverColor">#999999</Color>
        <Color x:Key="DisabledControlColor">#FFFFFF</Color>
        <Color x:Key="DisabledForegroundColor">#999999</Color>
        <Color x:Key="ControlPressedColor">#999999</Color>
        <!-- FocusVisual -->
        <Style x:Key="ButtonFocusVisual">
            <Setter Property="Control.Template">
                <Setter.Value>
                    <ControlTemplate>
                        <Border>
                            <Rectangle Margin="2" StrokeThickness="1" Stroke="#60000000" StrokeDashArray="1 2" />
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <!-- Button -->
        <Style TargetType="Button">
            <Setter Property="SnapsToDevicePixels" Value="true" />
            <Setter Property="OverridesDefaultStyle" Value="true" />
            <Setter Property="FocusVisualStyle" Value="{StaticResource ButtonFocusVisual}" />
            <Setter Property="MinHeight" Value="29px" />
            <Setter Property="MinWidth"  Value="103px" />
            <Setter Property="FontFamily" Value="Century Gothic" />
            <Setter Property="FontSize" Value="20" />
            <Setter Property="Foreground" Value="#999999" />
            <Setter Property="FontWeight" Value="Bold"></Setter>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Border TextBlock.Foreground="{TemplateBinding Foreground}" x:Name="Border">
                            <Border.Background>
                                <SolidColorBrush  Color="{DynamicResource ControlNormalColor}" />
                            </Border.Background>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualStateGroup.Transitions>
                                        <VisualTransition GeneratedDuration="0:0:0.5" />
                                        <VisualTransition GeneratedDuration="0" To="Pressed" />
                                    </VisualStateGroup.Transitions>
                                    <VisualState x:Name="Normal" />
                                    <VisualState x:Name="MouseOver">
                                        <Storyboard>
                                            <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Panel.Background).(SolidColorBrush.Color)"
                                        Storyboard.TargetName="Border">
                                                <EasingColorKeyFrame KeyTime="0" Value="{StaticResource ControlMouseOverColor}" />
                                            </ColorAnimationUsingKeyFrames>
                                            <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(TextBlock.Foreground).(SolidColorBrush.Color)"
                                        Storyboard.TargetName="Border">
                                                <EasingColorKeyFrame KeyTime="0" Value="{StaticResource ControlNormalColor}" />
                                            </ColorAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Pressed">
                                        <Storyboard>
                                            <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Panel.Background).(SolidColorBrush.Color)"
                                        Storyboard.TargetName="Border">
                                                <EasingColorKeyFrame KeyTime="0" Value="{StaticResource ControlPressedColor}" />
                                            </ColorAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Disabled">
                                        <Storyboard>
                                            <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Panel.Background).(SolidColorBrush.Color)"
                                        Storyboard.TargetName="Border">
                                                <EasingColorKeyFrame KeyTime="0" Value="{StaticResource DisabledControlColor}" />
                                            </ColorAnimationUsingKeyFrames>
                                            <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(TextBlock.Foreground).(SolidColorBrush.Color)"
                                        Storyboard.TargetName="Border">
                                                <EasingColorKeyFrame KeyTime="0" Value="{StaticResource DisabledForegroundColor}" />
                                            </ColorAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <ContentPresenter Margin="2"
                    HorizontalAlignment="Center"
                    VerticalAlignment="Center"
                    RecognizesAccessKey="True" />
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
