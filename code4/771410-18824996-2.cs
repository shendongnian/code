    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" Title="MainWindow" Height="350" Width="525" Loaded="Window_Loaded">
        <Grid>
            <Grid.Resources>
                <CollectionViewSource x:Key="ViewSource" Source="{Binding Path=Collection, UpdateSourceTrigger=PropertyChanged, RelativeSource={RelativeSource Mode=FindAncestor,
                AncestorType=Window} }">
                    <CollectionViewSource.GroupDescriptions>
                        <PropertyGroupDescription PropertyName="fake" />
                    </CollectionViewSource.GroupDescriptions>
                </CollectionViewSource>
            </Grid.Resources>
            <HeaderedItemsControl  Header="ListView">
                <StackPanel>
                    <ListView  ItemsSource="{Binding Source={StaticResource ViewSource}, UpdateSourceTrigger=PropertyChanged}" x:Name="Lv" Margin="5,5,5,5">
                        <ListView.GroupStyle>
                            <GroupStyle>
                                <GroupStyle.ContainerStyle>
                                    <Style TargetType="{x:Type GroupItem}">
                                        <Setter Property="Template">
                                            <Setter.Value>
                                                <ControlTemplate TargetType="{x:Type GroupItem}">
                                                    <DockPanel>
                                                        <Grid DockPanel.Dock="Bottom" >
                                                            <Grid.ColumnDefinitions>
                                                                <ColumnDefinition Width="{Binding ElementName=first, Path=Width, UpdateSourceTrigger=PropertyChanged}" />
                                                                <ColumnDefinition Width="{Binding ElementName=second, Path=Width, UpdateSourceTrigger=PropertyChanged}" />
                                                            </Grid.ColumnDefinitions>
                                                            <ScrollBar Grid.Column="0" Orientation="Horizontal" Scroll="ScrollBar1_Scroll"
                                                                  Width="{Binding ElementName=first, Path=Width, UpdateSourceTrigger=PropertyChanged,Mode=TwoWay}" >
                                                      
                                                            </ScrollBar>
                                                            <ScrollBar Grid.Column="1" Orientation="Horizontal" Scroll="ScrollBar2_Scroll"
                                                                       Width="{Binding ElementName=second, Path=Width, UpdateSourceTrigger=PropertyChanged,Mode=TwoWay}"/>
                                                        </Grid>
                                                        <ItemsPresenter />
                                                    </DockPanel>
                                                </ControlTemplate>
                                            </Setter.Value>
                                        </Setter>
                                    </Style>
                                </GroupStyle.ContainerStyle>
                            </GroupStyle>
                        </ListView.GroupStyle>
                        <ListView.View >
                    <GridView >
                                <GridViewColumn Header="Name"  x:Name="first" Width="50">
                                    <GridViewColumn.CellTemplate>
                                        <DataTemplate>
                                            <StackPanel Margin="{Binding Path=Offset1, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged, RelativeSource={RelativeSource Mode=FindAncestor,
                AncestorType=Window} }">
                                                <TextBlock x:Name="tb1"  Text="{Binding name}"></TextBlock>
                                            </StackPanel>
                                        </DataTemplate>
                                    </GridViewColumn.CellTemplate>
                                </GridViewColumn>
                                <GridViewColumn Header="Price" x:Name="second"  Width="50">
                                    <GridViewColumn.CellTemplate>
                                        <DataTemplate>
                                                <StackPanel Margin="{Binding Path=Offset2, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged, RelativeSource={RelativeSource Mode=FindAncestor,
                AncestorType=Window} }" >
                                                    <TextBlock Text="{Binding price}"></TextBlock>
                                                </StackPanel>
                                        </DataTemplate>
                                    </GridViewColumn.CellTemplate>
                                </GridViewColumn>
                            </GridView>
                </ListView.View>           
            </ListView>
                </StackPanel>
            </HeaderedItemsControl>
        </Grid>
    </Window>
