      <Grid>
        <Grid.Resources>
            <Style TargetType="toolkit:AutoCompleteBox" x:Key="AutoCompleteBoxStyle">
                <Setter Property="IsTabStop" Value="False" />
                <Setter Property="Padding" Value="2" />
                <Setter Property="BorderThickness" Value="1" />
                <Setter Property="BorderBrush">
                    <Setter.Value>
                        <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
                            <GradientStop Color="#FFA3AEB9" Offset="0" />
                            <GradientStop Color="#FF8399A9" Offset="0.375" />
                            <GradientStop Color="#FF718597" Offset="0.375" />
                            <GradientStop Color="#FF617584" Offset="1" />
                        </LinearGradientBrush>
                    </Setter.Value>
                </Setter>
                <Setter Property="Background" Value="#FFFFFFFF" />
                <Setter Property="Foreground" Value="#FF000000" />
                <Setter Property="MinWidth" Value="45" />
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="toolkit:AutoCompleteBox">
                            <Grid Opacity="{TemplateBinding Opacity}">
                                <!-- Fix for AutoCompleteBox ContextMenu - Added TemplateBinding between ContextMenu of Textbox inside template and control's ContextMenu  -->
                                <TextBox ContextMenu="{TemplateBinding ContextMenu}" Padding="{TemplateBinding Padding}" Background="{TemplateBinding Background}" IsTabStop="True" x:Name="Text" Style="{TemplateBinding TextBoxStyle}" BorderThickness="{TemplateBinding BorderThickness}" BorderBrush="{TemplateBinding BorderBrush}" Foreground="{TemplateBinding Foreground}" Margin="0" />
                                <Border x:Name="ValidationErrorElement" Visibility="Collapsed" BorderBrush="#FFDB000C" BorderThickness="1" CornerRadius="1">
                                    <ToolTipService.ToolTip>
                                        <ToolTip x:Name="validationTooltip" DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Template="{DynamicResource CommonValidationToolTipTemplate}" Placement="Right" PlacementTarget="{Binding RelativeSource={RelativeSource TemplatedParent}}">
                                            <ToolTip.Triggers>
                                                <EventTrigger RoutedEvent="Canvas.Loaded">
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
                                                </EventTrigger>
                                            </ToolTip.Triggers>
                                        </ToolTip>
                                    </ToolTipService.ToolTip>
                                    <Grid Height="12" HorizontalAlignment="Right" Margin="1,-4,-4,0" VerticalAlignment="Top" Width="12" Background="Transparent">
                                        <Path Fill="#FFDC000C" Margin="1,3,0,0" Data="M 1,0 L6,0 A 2,2 90 0 1 8,2 L8,7 z" />
                                        <Path Fill="#ffffff" Margin="1,3,0,0" Data="M 0,0 L2,0 L 8,6 L8,8" />
                                    </Grid>
                                </Border>
                                <Popup x:Name="Popup">
                                    <Grid Opacity="{TemplateBinding Opacity}" Background="{TemplateBinding Background}" >
                                        <Border x:Name="PopupBorder" HorizontalAlignment="Stretch" Opacity="0" BorderThickness="0">
                                            <Border.RenderTransform>
                                                <TranslateTransform X="1" Y="1" />
                                            </Border.RenderTransform>
                                            <Border.Background>
                                                <SolidColorBrush Color="#11000000" />
                                            </Border.Background>
                                            <Border HorizontalAlignment="Stretch" Opacity="1.0" Padding="0" BorderThickness="{TemplateBinding BorderThickness}" BorderBrush="{TemplateBinding BorderBrush}" CornerRadius="0">
                                                <Border.RenderTransform>
                                                    <TransformGroup>
                                                        <TranslateTransform X="-1" Y="-1" />
                                                    </TransformGroup>
                                                </Border.RenderTransform>
                                                <Border.Background>
                                                    <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
                                                        <GradientStop Color="#FFDDDDDD" Offset="0" />
                                                        <GradientStop Color="#AADDDDDD" Offset="1" />
                                                    </LinearGradientBrush>
                                                </Border.Background>
                                                <ListBox x:Name="Selector" ScrollViewer.HorizontalScrollBarVisibility="Auto" ScrollViewer.VerticalScrollBarVisibility="Auto" ItemContainerStyle="{TemplateBinding ItemContainerStyle}" Background="{TemplateBinding Background}" Foreground="{TemplateBinding Foreground}" BorderThickness="0" ItemTemplate="{TemplateBinding ItemTemplate}" />
                                            </Border>
                                        </Border>
                                    </Grid>
                                </Popup>
                                <vsm:VisualStateManager.VisualStateGroups>
                                    <vsm:VisualStateGroup x:Name="PopupStates">
                                        <vsm:VisualStateGroup.Transitions>
                                            <vsm:VisualTransition GeneratedDuration="0:0:0.1" To="PopupOpened" />
                                            <vsm:VisualTransition GeneratedDuration="0:0:0.2" To="PopupClosed" />
                                        </vsm:VisualStateGroup.Transitions>
                                        <vsm:VisualState x:Name="PopupOpened">
                                            <Storyboard>
                                                <DoubleAnimation Storyboard.TargetName="PopupBorder" Storyboard.TargetProperty="Opacity" To="1.0" Duration="0:0:0.1" />
                                            </Storyboard>
                                        </vsm:VisualState>
                                        <vsm:VisualState x:Name="PopupClosed">
                                            <Storyboard>
                                                <DoubleAnimation Storyboard.TargetName="PopupBorder" Storyboard.TargetProperty="Opacity" To="0" Duration="0:0:0.2" />
                                            </Storyboard>
                                        </vsm:VisualState>
                                    </vsm:VisualStateGroup>
                                    <vsm:VisualStateGroup x:Name="ValidationStates">
                                        <vsm:VisualState x:Name="Valid" />
                                        <vsm:VisualState>
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
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Grid.Resources>
        <Grid.RowDefinitions>
            <RowDefinition></RowDefinition>
            <RowDefinition></RowDefinition>
        </Grid.RowDefinitions>
        <toolkit:AutoCompleteBox Style="{DynamicResource AutoCompleteBoxStyle}">
            <toolkit:AutoCompleteBox.ContextMenu>
                <ContextMenu>
                    <MenuItem Header="Menu Item 1"></MenuItem>
                    <MenuItem Header="Menu Item 2"></MenuItem>
                </ContextMenu>
            </toolkit:AutoCompleteBox.ContextMenu>
        </toolkit:AutoCompleteBox>
        <TextBox Grid.Row="1" >
            <TextBox.ContextMenu>
                <ContextMenu>
                    <MenuItem Header="Menu Item 1"></MenuItem>
                    <MenuItem Header="Menu Item 2"></MenuItem>
                </ContextMenu>
            </TextBox.ContextMenu>
        </TextBox>
    </Grid>
