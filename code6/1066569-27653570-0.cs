            <Style x:Key="FullHeightButton" TargetType="Button">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="Button">
                            <Grid x:Name="Grid" Background="Transparent">
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="CommonStates">
                                        <VisualStateGroup.Transitions>
                                            <VisualTransition From="Pressed" To="PointerOver">
                                                <Storyboard>
                                                    <PointerUpThemeAnimation Storyboard.TargetName="Grid"/>
                                                </Storyboard>
                                            </VisualTransition>
                                            <VisualTransition From="PointerOver" To="Normal">
                                                <Storyboard>
                                                    <PointerUpThemeAnimation Storyboard.TargetName="Grid"/>
                                                </Storyboard>
                                            </VisualTransition>
                                            <VisualTransition From="Pressed" To="Normal">
                                                <Storyboard>
                                                    <PointerUpThemeAnimation Storyboard.TargetName="Grid"/>
                                                </Storyboard>
                                            </VisualTransition>
                                        </VisualStateGroup.Transitions>
                                        <VisualState x:Name="Normal"/>
                                        <VisualState x:Name="PointerOver"/>
                                        <VisualState x:Name="Pressed">
                                            <Storyboard>
                                                <PointerDownThemeAnimation Storyboard.TargetName="Grid"/>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="ContentPresenter">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource ButtonPressedForegroundThemeBrush}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="Border">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource ButtonPressedBackgroundThemeBrush}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Disabled">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="ContentPresenter">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource ButtonDisabledForegroundThemeBrush}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="Border">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource ButtonDisabledBorderThemeBrush}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="Border">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource ButtonDisabledBackgroundThemeBrush}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <Border x:Name="Border" CornerRadius="5" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="0" Background="{TemplateBinding Background}">
                                    <Viewbox> /* VIEWBOX ADDED */
                                        <ContentPresenter x:Name="ContentPresenter" AutomationProperties.AccessibilityView="Raw" 
                                                               ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" 
                                                               Foreground="{TemplateBinding Foreground}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" 
                                                               Margin="{TemplateBinding Padding}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                                    </Viewbox>
                                </Border>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
