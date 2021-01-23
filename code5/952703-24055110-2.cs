        <TabControl Grid.Column="1" Margin="4">
            <TabControl.Items>
                <sys:String>Positions</sys:String>
                <sys:String>Orders</sys:String>
                <sys:String>Trade</sys:String>
            </TabControl.Items>
            <TabControl.Style>
                <Style BasedOn="{StaticResource {x:Type TabControl}}" TargetType="{x:Type TabControl}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type TabControl}">
                                <Grid KeyboardNavigation.TabNavigation="Local">
                                    <Grid.RowDefinitions>
                                        <RowDefinition Height="Auto" />
                                        <RowDefinition Height="*" />
                                    </Grid.RowDefinitions>
                                    <VisualStateManager.VisualStateGroups>
                                        <VisualStateGroup x:Name="CommonStates">
                                            <VisualState x:Name="Disabled">
                                                <Storyboard>
                                                    <ColorAnimationUsingKeyFrames Storyboard.TargetName="Border" Storyboard.TargetProperty="(Border.BorderBrush).
                    (SolidColorBrush.Color)">
                                                        <EasingColorKeyFrame KeyTime="0" Value="#FFAAAAAA" />
                                                    </ColorAnimationUsingKeyFrames>
                                                </Storyboard>
                                            </VisualState>
                                        </VisualStateGroup>
                                    </VisualStateManager.VisualStateGroups>
                                    <Grid>
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition Width="auto" />
                                            <ColumnDefinition />
                                        </Grid.ColumnDefinitions>
                                        <ToggleButton x:Name="toggle" Content="v" IsChecked="True" VerticalAlignment="Top" Width="{Binding Path=ActualHeight,RelativeSource={RelativeSource Self}}" />
                                        <TabPanel Grid.Column="1" x:Name="HeaderPanel" Grid.Row="0" Panel.ZIndex="1" Margin="4,0" IsItemsHost="True" KeyboardNavigation.TabIndex="1" Background="Transparent" />
                                    </Grid>
                                    <Border x:Name="Border" Grid.Row="1" BorderThickness="1" CornerRadius="2" KeyboardNavigation.TabNavigation="Local" KeyboardNavigation.DirectionalNavigation="Contained" KeyboardNavigation.TabIndex="2"
                                            Visibility="{Binding IsChecked, ElementName=toggle,Converter={StaticResource BooleanToVisibilityConverter}}">
                                        <Border.Background>
                                            <SolidColorBrush Color="{DynamicResource {x:Static SystemColors.WindowColorKey}}" />
                                        </Border.Background>
                                        <Border.BorderBrush>
                                            <SolidColorBrush Color="{DynamicResource {x:Static SystemColors.ActiveBorderColorKey}}" />
                                        </Border.BorderBrush>
                                        <ContentPresenter x:Name="PART_SelectedContentHost" Margin="4" ContentSource="SelectedContent" />
                                    </Border>
                                </Grid>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </TabControl.Style>
        </TabControl>
