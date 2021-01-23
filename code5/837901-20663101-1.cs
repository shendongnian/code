    <Setter Property="Template">
    <Setter.Value>
        <ControlTemplate TargetType="Expander">
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Name="ContentRow" Height="0"/>
                </Grid.RowDefinitions>
                <Border x:Name="ExpanderOuterBorder"
                      CornerRadius="0"
                      BorderThickness="1">
                    <Border.BorderBrush>
                        <SolidColorBrush x:Name="ExpanderBorderColor" Color="LightBlue"/>
                    </Border.BorderBrush>
                    <Border.Background>
                        <SolidColorBrush x:Name="ExpanderBackgroundColor" Color="White"/>
                    </Border.Background>
                    <Grid>
                        <ToggleButton
                              OverridesDefaultStyle="True"
                              Template="{StaticResource CustomToggleButton}"
                              IsChecked="{Binding Path=IsExpanded, Mode=TwoWay, RelativeSource={RelativeSource TemplatedParent}}"
                              Grid.Column="0">
                            <ToggleButton.Content>
                                <ContentPresenter ContentSource="Header"/>
                            </ToggleButton.Content>
                        </ToggleButton>
                    </Grid>
                </Border>
                <Border Name="Content" 
                          Grid.Row="1">
                    <ContentPresenter/>
                </Border>
            </Grid>
            <ControlTemplate.Triggers>
                <EventTrigger RoutedEvent="MouseEnter">
                    <BeginStoryboard>
                        <Storyboard>
                            <ColorAnimation
                                    Storyboard.TargetName="ExpanderBackgroundColor"
                                    Storyboard.TargetProperty="Color"
                                    To="LightBlue"
                                    Duration="0:0:0.1"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
                <EventTrigger RoutedEvent="MouseLeave">
                    <BeginStoryboard>
                        <Storyboard>
                            <ColorAnimation
                                    Storyboard.TargetName="ExpanderBackgroundColor"
                                    Storyboard.TargetProperty="Color"
                                    To="White"
                                    Duration="0:0:0.1"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
                <Trigger Property="IsExpanded" Value="True">
                    <Setter TargetName="ContentRow" Property="Height" Value="{Binding ElementName=Content, Path=Height}" />
                </Trigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>
    </Setter.Value>
