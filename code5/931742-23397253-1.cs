    <TabControl Name="TabControl">
            <TabControl.Resources>
                <Style TargetType="{x:Type TabItem}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type TabItem}">
                                <Grid>
                                    <Border 
                                        Name="Border"
                                        Margin="0,0,-4,0" 
                                        Background="BlueViolet"
                                        BorderBrush="{StaticResource SolidBorderBrush}" 
                                        BorderThickness="1,1,1,1" 
                                        CornerRadius="2,12,0,0" >
                                        <ContentPresenter x:Name="ContentSite"
                                          VerticalAlignment="Center"
                                          HorizontalAlignment="Center"
                                          ContentSource="Header"
                                          Margin="12,2,12,2"
                                          RecognizesAccessKey="True"/>
                                    </Border>
                                </Grid>
                                <ControlTemplate.Triggers>
                                    <Trigger Property="IsSelected" Value="True">
                                        <Setter Property="Panel.ZIndex" Value="100" />
                                        <Setter TargetName="Border" Property="Background" Value="BlueViolet" />
                                        <Setter TargetName="Border" Property="BorderThickness" Value="1,1,1,0" />
                                    </Trigger>
                                    <Trigger Property="IsEnabled" Value="False">
                                        <Setter TargetName="Border" Property="Background" Value="{StaticResource DisabledBackgroundBrush}" />
                                        <Setter TargetName="Border" Property="BorderBrush" Value="{StaticResource DisabledBorderBrush}" />
                                        <Setter Property="Foreground" Value="{StaticResource DisabledForegroundBrush}" />
                                    </Trigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </TabControl.Resources>
            <TabControl.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <TextBlock Height="20" Width="60" Text="TEST"/>
                    </Grid>
                </DataTemplate>
            </TabControl.ItemTemplate>
    </TabControl>
