    <phone:PhoneApplicationPage ...>
    <phone:PhoneApplicationPage.Resources>
        <Style x:Key="ButtonStyle1" TargetType="Button">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Grid Background="Transparent">
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualState x:Name="Normal"/>
                                    <VisualState x:Name="MouseOver"/>
                                    <VisualState x:Name="Pressed">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="ContentContainer">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneBackgroundBrush}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="ButtonBackground">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneForegroundBrush}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ColorAnimation Duration="0" To="Cyan" Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)" Storyboard.TargetName="ButtonBackground" d:IsOptimized="True"/>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Disabled">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="ContentContainer">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneDisabledBrush}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="ButtonBackground">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneDisabledBrush}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <Border x:Name="ButtonBackground" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" CornerRadius="0" Margin="{StaticResource PhoneTouchTargetOverhang}" Background="Black">
                                <ContentControl x:Name="ContentContainer" ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" Foreground="{TemplateBinding Foreground}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Padding="{TemplateBinding Padding}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                            </Border>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </phone:PhoneApplicationPage.Resources>
    <Grid x:Name="LayoutRoot" Background="Transparent">
        <Button Content="Button" Style="{StaticResource ButtonStyle1}"/>
    </Grid>
