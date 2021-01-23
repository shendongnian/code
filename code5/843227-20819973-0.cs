    <TreeView Grid.Column="0" Name="FolderView">
            <TreeView.Resources>
                <Style TargetType="{x:Type TreeViewItem}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="TreeViewItem">
                                <Grid Background="Transparent">
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition MinWidth="25" Width="Auto" />
                                        <ColumnDefinition Width="Auto"/>
                                        <ColumnDefinition Width="*"/>
                                    </Grid.ColumnDefinitions>
                                    <Grid.RowDefinitions>
                                        <RowDefinition Height="Auto"/>
                                        <RowDefinition/>
                                    </Grid.RowDefinitions>
                                    <ToggleButton x:Name="Expander"  IsChecked="{Binding Path=IsExpanded,RelativeSource={RelativeSource TemplatedParent}}" ClickMode="Press">
                                        <ToggleButton.Style>
                                            <Style TargetType="ToggleButton">
                                                <Setter Property="Template">
                                                    <Setter.Value>
                                                        <ControlTemplate TargetType="ToggleButton">
                                                            <Border Height="0" Width="0"/>
                                                        </ControlTemplate>
                                                    </Setter.Value>
                                                </Setter>
                                            </Style>
                                        </ToggleButton.Style>
                                    </ToggleButton>
                                    <ContentPresenter x:Name="PART_Header" ContentSource="Header"/>
                                    <Grid x:Name="ItemsHost" Grid.Row="1" Grid.Column="1" Grid.ColumnSpan="2"  Margin="0,-5,0,0">
                                        <ItemsPresenter />
                                    </Grid>
                                </Grid>
                                <ControlTemplate.Triggers>
                                    <Trigger Property="IsExpanded" Value="false">
                                        <Setter TargetName="ItemsHost" Property="Visibility"  Value="Collapsed"/>
                                    </Trigger>
                                    <Trigger Property="HasItems"  Value="false">
                                        <Setter TargetName="Expander" Property="Visibility" Value="Hidden"/>
                                    </Trigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="HeaderTemplate">
                        <Setter.Value>
                            <DataTemplate>
                                <StackPanel Orientation="Horizontal">
                                    <Image Name="img" Width="16" Height="16" Stretch="Fill" Source="Images/Folder.png" Margin="3" VerticalAlignment="Center"/>
                                    <TextBlock Text="{Binding}" Margin="0,0" VerticalAlignment="Center" />
                                </StackPanel>
                            </DataTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </TreeView.Resources>
        </TreeView>
