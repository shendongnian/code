      <Style TargetType="TextBox">
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="Background" Value="#FFFFFFFF"/>
            <Setter Property="Foreground" Value="#FF000000"/>
            <Setter Property="Padding" Value="2"/>
            <Setter Property="BorderBrush">
                <Setter.Value>
                    <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
                        <GradientStop Color="#FFA3AEB9" Offset="0"/>
                        <GradientStop Color="#FF8399A9" Offset="0.375"/>
                        <GradientStop Color="#FF718597" Offset="0.375"/>
                        <GradientStop Color="#FF617584" Offset="1"/>
                    </LinearGradientBrush>
                </Setter.Value>
            </Setter>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="TextBox">
                        <Grid x:Name="RootElement">
                            <vsm:VisualStateManager.VisualStateGroups>
                                <vsm:VisualStateGroup x:Name="CommonStates">
                                    <vsm:VisualState x:Name="Normal"/>
                                    <vsm:VisualState x:Name="MouseOver">
                                        <Storyboard>
                                            <ColorAnimation Storyboard.TargetName="MouseOverBorder" Storyboard.TargetProperty="(Border.BorderBrush).(SolidColorBrush.Color)" To="#FF99C1E2" Duration="0"/>
                                        </Storyboard>
                                    </vsm:VisualState>
                                    <vsm:VisualState x:Name="Disabled">
                                        <!--<Storyboard>
                                            <DoubleAnimation Storyboard.TargetName="DisabledVisualElement" Storyboard.TargetProperty="Opacity" To="1" Duration="0"/>
                                        </Storyboard>-->
                                    </vsm:VisualState>
                                    <vsm:VisualState x:Name="ReadOnly">
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetName="ReadOnlyVisualElement" Storyboard.TargetProperty="Opacity" To="1" Duration="0" />
                                        </Storyboard>
                                    </vsm:VisualState>
                                </vsm:VisualStateGroup>
                                <vsm:VisualStateGroup x:Name="FocusStates">
                                    <vsm:VisualState x:Name="Focused">
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetName="FocusVisualElement" Storyboard.TargetProperty="Opacity" To="1" Duration="0"/>
                                        </Storyboard>
                                    </vsm:VisualState>
                                    <vsm:VisualState x:Name="Unfocused">
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetName="FocusVisualElement" Storyboard.TargetProperty="Opacity" To="0" Duration="0"/>
                                        </Storyboard>
                                    </vsm:VisualState>
                                </vsm:VisualStateGroup>
                                <vsm:VisualStateGroup x:Name="ValidationStates">
                                    <vsm:VisualState x:Name="Valid"/>
                                    <vsm:VisualState x:Name="InvalidUnfocused">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ValidationErrorElement" Storyboard.TargetProperty="Visibility">
                                                <DiscreteObjectKeyFrame KeyTime="0">
                                                    <DiscreteObjectKeyFrame.Value>
                                                        <Visibility>Visible</Visibility>
                                                    </DiscreteObjectKeyFrame.Value>
                                                </DiscreteObjectKeyFrame>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </vsm:VisualState>
                                    <vsm:VisualState x:Name="InvalidFocused">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ValidationErrorElement" Storyboard.TargetProperty="Visibility">
                                                <DiscreteObjectKeyFrame KeyTime="0">
                                                    <DiscreteObjectKeyFrame.Value>
                                                        <Visibility>Visible</Visibility>
                                                    </DiscreteObjectKeyFrame.Value>
                                                </DiscreteObjectKeyFrame>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="validationTooltip" Storyboard.TargetProperty="IsOpen">
                                                <DiscreteObjectKeyFrame KeyTime="0">
                                                    <DiscreteObjectKeyFrame.Value>
                                                        <sys:Boolean>True</sys:Boolean>
                                                    </DiscreteObjectKeyFrame.Value>
                                                </DiscreteObjectKeyFrame>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </vsm:VisualState>
                                </vsm:VisualStateGroup>
                            </vsm:VisualStateManager.VisualStateGroups>
                            <Border x:Name="Border" BorderThickness="{TemplateBinding BorderThickness}" CornerRadius="1" Opacity="1" Background="{TemplateBinding Background}" BorderBrush="{TemplateBinding BorderBrush}">
                                <Grid>
                                    <Border x:Name="ReadOnlyVisualElement" Opacity="0" Background="#5EC9C9C9"/>
                                    <Border x:Name="MouseOverBorder" BorderThickness="1" BorderBrush="Transparent">
                                        <ScrollViewer x:Name="ContentElement" Padding="{TemplateBinding Padding}" BorderThickness="0" IsTabStop="False"/>
                                    </Border>
                                </Grid>
                            </Border>
                            <Border x:Name="DisabledVisualElement" Background="#A5F7F7F7" BorderBrush="#A5F7F7F7" BorderThickness="{TemplateBinding BorderThickness}" Opacity="0" IsHitTestVisible="False"/>
                            <Border x:Name="FocusVisualElement" BorderBrush="#FF6DBDD1" BorderThickness="{TemplateBinding BorderThickness}" Margin="1" Opacity="0" IsHitTestVisible="False"/>
                            <Border x:Name="ValidationErrorElement" BorderThickness="1" CornerRadius="1" BorderBrush="#FFDB000C" Visibility="Collapsed">
                                <ToolTipService.ToolTip>
                                    <ToolTip x:Name="validationTooltip" Template="{StaticResource ValidationToolTipTemplate}" Placement="Right" 
                         PlacementTarget="{Binding RelativeSource={RelativeSource TemplatedParent}}"
                         DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}">
                                        <ToolTip.Triggers>
                                            <EventTrigger RoutedEvent="Canvas.Loaded">
                                                <EventTrigger.Actions>
                                                    <BeginStoryboard>
                                                        <Storyboard>
                                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="validationTooltip" Storyboard.TargetProperty="IsHitTestVisible">
                                                                <DiscreteObjectKeyFrame KeyTime="0">
                                                                    <DiscreteObjectKeyFrame.Value>
                                                                        <sys:Boolean>true</sys:Boolean>
                                                                    </DiscreteObjectKeyFrame.Value>
                                                                </DiscreteObjectKeyFrame>
                                                            </ObjectAnimationUsingKeyFrames>
                                                        </Storyboard>
                                                    </BeginStoryboard>
                                                </EventTrigger.Actions>
                                            </EventTrigger>
                                        </ToolTip.Triggers>
                                    </ToolTip>
                                </ToolTipService.ToolTip>
                                <Grid Width="12" Height="12" HorizontalAlignment="Right" Margin="1,-4,-4,0" VerticalAlignment="Top" Background="Transparent">
                                    <Path Margin="1,3,0,0" Data="M 1,0 L6,0 A 2,2 90 0 1 8,2 L8,7 z" Fill="#FFDC000C"/>
                                    <Path Margin="1,3,0,0" Data="M 0,0 L2,0 L 8,6 L8,8" Fill="#ffffff"/>
                                </Grid>
                            </Border>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
