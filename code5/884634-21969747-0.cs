    <Style x:Key="HubTileStyle1" TargetType="toolkit:HubTile">
        <Setter Property="Height" Value="400"/>
        <Setter Property="Width" Value="400"/>
        <Setter Property="Background" Value="{StaticResource PhoneAccentBrush}"/>
        <Setter Property="Foreground" Value="#FFFFFFFF"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="toolkit:HubTile">
                    <Border x:Name="Container" Width="400" Height="400">
                        <Border.Resources>
                            <CubicEase x:Key="HubTileEaseOut" EasingMode="EaseOut"/>
                        </Border.Resources>
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="ImageStates">
                                <VisualStateGroup.Transitions>
                                    <VisualTransition x:Name="ExpandedToSemiexpanded" From="Expanded" GeneratedDuration="0:0:0.85" To="Semiexpanded">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="TitlePanel">
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.0" Value="-400"/>
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.85" Value="-182.64"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="RotationX" Storyboard.TargetName="ViewportProjection">
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.0" Value="0.0"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualTransition>
                                    <VisualTransition x:Name="SemiexpandedToExpanded" From="Semiexpanded" GeneratedDuration="0:0:0.85" To="Expanded">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="TitlePanel">
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.0" Value="-182.64"/>
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.85" Value="-400"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualTransition>
                                    <VisualTransition x:Name="SemiexpandedToCollapsed" From="Semiexpanded" GeneratedDuration="0:0:0.85" To="Collapsed">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="TitlePanel">
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.0" Value="-182.64"/>
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.85" Value="0.0"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualTransition>
                                    <VisualTransition x:Name="CollapsedToExpanded" From="Collapsed" GeneratedDuration="0:0:0.85" To="Expanded">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="TitlePanel">
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.0" Value="0.0"/>
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.85" Value="-400"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualTransition>
                                    <VisualTransition x:Name="ExpandedToFlipped" From="Expanded" GeneratedDuration="0:0:0.85" To="Flipped">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="TitlePanel">
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.0" Value="-400"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="Image">
                                                <DiscreteObjectKeyFrame KeyTime="0:0:0.185" Value="Collapsed"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="BackPanel">
                                                <DiscreteObjectKeyFrame KeyTime="0:0:0.185" Value="Visible"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="RotationX" Storyboard.TargetName="ViewportProjection">
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.0" Value="0.0"/>
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.85" Value="180.0"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualTransition>
                                    <VisualTransition x:Name="FlippedToExpanded" From="Flipped" GeneratedDuration="0:0:0.85" To="Expanded">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="TitlePanel">
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.0" Value="-400"/>
                                            </DoubleAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="Image">
                                                <DiscreteObjectKeyFrame KeyTime="0:0:0.185" Value="Visible"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="BackPanel">
                                                <DiscreteObjectKeyFrame KeyTime="0:0:0.185" Value="Collapsed"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="RotationX" Storyboard.TargetName="ViewportProjection">
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.0" Value="180.0"/>
                                                <EasingDoubleKeyFrame EasingFunction="{StaticResource HubTileEaseOut}" KeyTime="0:0:0.85" Value="360.0"/>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualTransition>
                                </VisualStateGroup.Transitions>
                                <VisualState x:Name="Expanded">
                                    <Storyboard>
                                        <DoubleAnimation Duration="0" To="-400" Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="TitlePanel"/>
                                        <DoubleAnimation Duration="0" To="0.0" Storyboard.TargetProperty="RotationX" Storyboard.TargetName="ViewportProjection"/>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="Image">
                                            <DiscreteObjectKeyFrame KeyTime="0:0:0" Value="Visible"/>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Semiexpanded">
                                    <Storyboard>
                                        <DoubleAnimation Duration="0" To="-182.64" Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="TitlePanel"/>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Collapsed"/>
                                <VisualState x:Name="Flipped">
                                    <Storyboard>
                                        <DoubleAnimation Duration="0" To="400" Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateY)" Storyboard.TargetName="TitlePanel"/>
                                        <DoubleAnimation Duration="0" To="180.0" Storyboard.TargetProperty="RotationX" Storyboard.TargetName="ViewportProjection"/>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="Image">
                                            <DiscreteObjectKeyFrame KeyTime="0:0:0" Value="Collapsed"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="BackPanel">
                                            <DiscreteObjectKeyFrame KeyTime="0:0:0" Value="Visible"/>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <StackPanel x:Name="Viewport" Height="400" Width="400">
                            <StackPanel.Projection>
                                <PlaneProjection x:Name="ViewportProjection" CenterOfRotationY="0.25"/>
                            </StackPanel.Projection>
                            <Grid x:Name="TitlePanel" Height="800" RenderTransformOrigin="0.5,0.5" Width="400">
                                <Grid.RowDefinitions>
                                    <RowDefinition/>
                                    <RowDefinition/>
                                </Grid.RowDefinitions>
                                <Grid.RenderTransform>
                                    <CompositeTransform/>
                                </Grid.RenderTransform>
                                <Border Background="{TemplateBinding Background}" Grid.Row="0">
                                    <TextBlock Foreground="{TemplateBinding Foreground}" FontSize="41" FontFamily="{StaticResource PhoneFontFamilyNormal}" LineStackingStrategy="BlockLineHeight" LineHeight="39" Margin="10,0,0,6" TextWrapping="NoWrap" Text="{TemplateBinding Title}" VerticalAlignment="Bottom"/>
                                </Border>
                                <Grid x:Name="BackPanel" Background="{TemplateBinding Background}" Height="400" Grid.Row="1" Visibility="Collapsed" Width="400">
                                    <Grid.Projection>
                                        <PlaneProjection CenterOfRotationY="0.5" RotationX="180"/>
                                    </Grid.Projection>
                                    <Grid.RowDefinitions>
                                        <RowDefinition Height="*"/>
                                        <RowDefinition Height="Auto"/>
                                    </Grid.RowDefinitions>
                                    <TextBlock x:Name="NotificationBlock" Foreground="{TemplateBinding Foreground}" FontSize="{StaticResource PhoneFontSizeLarge}" FontFamily="{StaticResource PhoneFontFamilyNormal}" LineStackingStrategy="BlockLineHeight" LineHeight="32" Margin="8,8,0,6" Grid.Row="0" TextWrapping="NoWrap" Text="{TemplateBinding Notification}"/>
                                    <TextBlock x:Name="MessageBlock" Foreground="{TemplateBinding Foreground}" FontSize="{StaticResource PhoneFontSizeNormal}" FontFamily="{StaticResource PhoneFontFamilyNormal}" LineStackingStrategy="BlockLineHeight" LineHeight="23.333" Margin="10,10,10,6" Grid.Row="0" TextWrapping="Wrap" Text="{TemplateBinding Message}"/>
                                    <TextBlock x:Name="BackTitleBlock" Foreground="{TemplateBinding Foreground}" FontSize="{StaticResource PhoneFontSizeNormal}" FontFamily="{StaticResource PhoneFontFamilySemiBold}" Margin="10,0,0,6" Grid.Row="1" TextWrapping="NoWrap" VerticalAlignment="Bottom"/>
                                </Grid>
                                <Border x:Name="Image" Background="{TemplateBinding Background}" Grid.Row="1">
                                    <Image Height="400" Source="{TemplateBinding Source}" Stretch="UniformToFill" Width="400"/>
                                </Border>
                            </Grid>
                        </StackPanel>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
