    <Style TargetType="controls:WatermarkTextBox">
        <Setter Property="FontFamily" Value="{StaticResource PhoneFontFamilyNormal}"/>
        <Setter Property="FontSize" Value="{StaticResource PhoneFontSizeMediumLarge}"/>
        <Setter Property="Background" Value="{StaticResource PhoneTextBoxBrush}"/>
        <Setter Property="Foreground" Value="{StaticResource PhoneTextBoxForegroundBrush}"/>
        <Setter Property="BorderBrush" Value="{StaticResource PhoneTextBoxBrush}"/>
        <Setter Property="SelectionBackground" Value="{StaticResource PhoneAccentBrush}"/>
        <Setter Property="SelectionForeground" Value="{StaticResource PhoneTextBoxSelectionForegroundBrush}"/>
        <Setter Property="BorderThickness" Value="{StaticResource PhoneBorderThickness}"/>
        <Setter Property="Padding" Value="2"/>
        <Setter Property="WatermarkTextForeground" Value="#FF868686" />
        <Setter Property="WatermarkTextStyle">
            <Setter.Value>
                <Style TargetType="TextBlock">
                    <Setter Property="HorizontalAlignment" Value="Left" />
                    <Setter Property="VerticalAlignment" Value="Center" />
                    <Setter Property="Margin" Value="20,0,0,0" />
                    <Setter Property="TextWrapping" Value="NoWrap" />
                </Style>
            </Setter.Value>
        </Setter>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="controls:WatermarkTextBox">
                    <Grid Background="Transparent">
                        <Grid.Resources>
                            <ControlTemplate x:Key="PhoneDisabledTextBoxTemplate" TargetType="controls:WatermarkTextBox">
                                <ContentControl x:Name="ContentElement" BorderThickness="0" HorizontalContentAlignment="Stretch" Margin="{StaticResource PhoneTextBoxInnerMargin}" Padding="{TemplateBinding Padding}" VerticalContentAlignment="Stretch"/>
                            </ControlTemplate>
                        </Grid.Resources>
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="CommonStates">
                                <VisualState x:Name="Normal"/>
                                <VisualState x:Name="MouseOver"/>
                                <VisualState x:Name="Disabled">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="EnabledBorder">
                                            <DiscreteObjectKeyFrame KeyTime="0">
                                                <DiscreteObjectKeyFrame.Value>
                                                    <Visibility>Collapsed</Visibility>
                                                </DiscreteObjectKeyFrame.Value>
                                            </DiscreteObjectKeyFrame>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="DisabledOrReadonlyBorder">
                                            <DiscreteObjectKeyFrame KeyTime="0">
                                                <DiscreteObjectKeyFrame.Value>
                                                    <Visibility>Visible</Visibility>
                                                </DiscreteObjectKeyFrame.Value>
                                            </DiscreteObjectKeyFrame>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="ReadOnly">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="EnabledBorder">
                                            <DiscreteObjectKeyFrame KeyTime="0">
                                                <DiscreteObjectKeyFrame.Value>
                                                    <Visibility>Collapsed</Visibility>
                                                </DiscreteObjectKeyFrame.Value>
                                            </DiscreteObjectKeyFrame>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="DisabledOrReadonlyBorder">
                                            <DiscreteObjectKeyFrame KeyTime="0">
                                                <DiscreteObjectKeyFrame.Value>
                                                    <Visibility>Visible</Visibility>
                                                </DiscreteObjectKeyFrame.Value>
                                            </DiscreteObjectKeyFrame>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="DisabledOrReadonlyBorder">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneTextBoxBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="DisabledOrReadonlyBorder">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneTextBoxBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="DisabledOrReadonlyContent">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneTextBoxReadOnlyBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="FocusStates">
                                <VisualState x:Name="Focused">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="EnabledBorder">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneTextBoxEditBackgroundBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="EnabledBorder">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneTextBoxEditBorderBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Unfocused"/>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="WatermarkTextStates">
                                <VisualState x:Name="WatermarkTextVisible">
                                    <Storyboard>
                                        <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="WatermarkTextBlock" Storyboard.TargetProperty="(UIElement.Opacity)">
                                            <EasingDoubleKeyFrame KeyTime="00:00:00" Value="1"/>
                                        </DoubleAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="WatermarkTextHidden">
                                    <Storyboard>
                                        <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Duration="00:00:00.0010000" Storyboard.TargetName="WatermarkTextBlock" Storyboard.TargetProperty="(UIElement.Opacity)">
                                            <EasingDoubleKeyFrame KeyTime="00:00:00" Value="0"/>
                                        </DoubleAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <Border x:Name="EnabledBorder" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Margin="{StaticResource PhoneTouchTargetOverhang}">
                            <ContentControl x:Name="ContentElement" BorderThickness="0" HorizontalContentAlignment="Stretch" Margin="{StaticResource PhoneTextBoxInnerMargin}" Padding="{TemplateBinding Padding}" VerticalContentAlignment="Stretch"/>
                        </Border>
                        <Border x:Name="DisabledOrReadonlyBorder" BorderBrush="{StaticResource PhoneDisabledBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="Transparent" Margin="{StaticResource PhoneTouchTargetOverhang}" Visibility="Collapsed">
                            <TextBox x:Name="DisabledOrReadonlyContent" Background="Transparent" Foreground="{StaticResource PhoneDisabledBrush}" FontWeight="{TemplateBinding FontWeight}" FontStyle="{TemplateBinding FontStyle}" FontSize="{TemplateBinding FontSize}" FontFamily="{TemplateBinding FontFamily}" IsReadOnly="True" SelectionForeground="{TemplateBinding SelectionForeground}" SelectionBackground="{TemplateBinding SelectionBackground}" TextAlignment="{TemplateBinding TextAlignment}" TextWrapping="{TemplateBinding TextWrapping}" Text="{TemplateBinding Text}" Template="{StaticResource PhoneDisabledTextBoxTemplate}"/>
                        </Border>
                        <TextBlock x:Name="WatermarkTextBlock" Style="{TemplateBinding WatermarkTextStyle}" Foreground="{TemplateBinding WatermarkTextForeground}" Text="{TemplateBinding WatermarkText}" IsHitTestVisible="False" Grid.ColumnSpan="2" />
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
