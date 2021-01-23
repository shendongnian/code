    <UserControl x:Class="Philips.HHDx.SSW.AnalyzerGroup.AnalyzerGroupWorkspaceView"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:cal="http://www.caliburnproject.org">
        <DockPanel>
            <GroupBox Header="AnalyzerGroups" DockPanel.Dock="Top">
                <ListBox SelectionMode="Single"
                         x:Name="AnalyzerGroups"
                         cal:Message.Attach="[Event SelectionChanged] = [Action SelectionChanged($eventArgs)]">
                    <ListBox.ItemContainerStyle>
                        <Style TargetType="{x:Type ListBoxItem}">
                            <Setter Property="IsSelected" Value="{Binding IsSelected}"/>
                        </Style>
                    </ListBox.ItemContainerStyle>
                    <ListBox.ItemsPanel>
                        <ItemsPanelTemplate>
                            <StackPanel Orientation="Horizontal" />
                        </ItemsPanelTemplate>
                    </ListBox.ItemsPanel>
                    <ListBox.ItemTemplate>
                        <DataTemplate>
                            <Border BorderThickness="2" BorderBrush="DarkGray">
                                <StackPanel Orientation="Vertical" Margin="10">
                                    <TextBlock Text="{Binding Name}" />
                                    <ListBox SelectionMode="Single" ItemsSource="{Binding Analyzers}" >
                                        <ListBox.ItemContainerStyle>
                                            <Style TargetType="{x:Type ListBoxItem}">
                                                <Setter Property="IsSelected" Value="{Binding IsSelected}"/>
                                            </Style>
                                        </ListBox.ItemContainerStyle>
                                        <ListBox.ItemsPanel>
                                            <ItemsPanelTemplate>
                                                <StackPanel Orientation="Horizontal"></StackPanel>
                                            </ItemsPanelTemplate>
                                        </ListBox.ItemsPanel>
                                        <ListBox.ItemTemplate>
                                            <DataTemplate>
                                                <Border BorderThickness="1" BorderBrush="DarkGray">
                                                    <StackPanel>
                                                        <TextBlock Text="{Binding Name }" Margin="10" />
                                                    </StackPanel>
                                                </Border>
                                            </DataTemplate>
                                        </ListBox.ItemTemplate>
                                    </ListBox>
                                </StackPanel>
                            </Border>
                        </DataTemplate>
                    </ListBox.ItemTemplate>
                </ListBox>
            </GroupBox>
            <GroupBox Header="Details">
                <ContentControl cal:View.Model="{Binding SelectedViewModel}" />
            </GroupBox>
        </DockPanel>
    </UserControl>
