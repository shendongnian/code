    <Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:c="clr-namespace:WpfModelViewDemoApplication.Commands"
    xmlns:vw="clr-namespace:WpfModelViewDemoApplication.Views"
    xmlns:vm="clr-namespace:WpfModelViewDemoApplication.ViewModels"
    x:Class="WpfModelViewDemoApplication.Views.MainView"
    mc:Ignorable="d"
    d:DataContext="{DynamicResource MainViewModel}"
    x:Name="MainWindow"
    FontFamily="Verdana"
    Title="WPF MVVM Tutorial">
    <Window.Resources>
    <vm:MainViewModel x:Key="MainViewModel"/>
    <DataTemplate x:Key="ResourceItemTemplate">
        <GridViewColumnHeader Content="Name"  Tag="{Binding DataContext, ElementName=MainWindow}">
            <GridViewColumnHeader.ContextMenu>
                <ContextMenu s>
                    <MenuItem Header="Time Added" IsCheckable="True" IsChecked="{Binding PlacementTarget.Tag.IsTimeAddedSelected,RelativeSource={RelativeSource AncestorType=ContextMenu}}"/>
                    <MenuItem Header="Comment" IsCheckable="True" IsChecked="{Binding PlacementTarget.Tag.IsCommentSelected,RelativeSource={RelativeSource AncestorType=ContextMenu}}"/>
                </ContextMenu>
            </GridViewColumnHeader.ContextMenu>
        </GridViewColumnHeader>
    </DataTemplate>
    </Window.Resources>
      <ListView x:Name="lstView" Grid.Row="2" BorderBrush="White" ItemsSource="{Binding Path=Students}" HorizontalAlignment="Stretch">
        <ListView.View>
            <GridView>
                <GridViewColumn HeaderContainerStyle="{StaticResource GridViewHeaderStyle}" HeaderTemplate="{StaticResource ResourceItemTemplate}" DisplayMemberBinding="{Binding Path=Name}"/>
                <GridViewColumn Header="Score" HeaderContainerStyle="{StaticResource GridViewHeaderStyle}" DisplayMemberBinding="{Binding Path=Score}" />
                <GridViewColumn Header="TimeAdded" HeaderContainerStyle="{StaticResource GridViewHeaderStyle}">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <Button Content="{Binding Path=TimeAdded}" Tag="{Binding DataContext, RelativeSource={RelativeSource AncestorType={x:Type vw:MainView}}}">
                                <Button.ToolTip>
                                    <ToolTip DataContext="{Binding Path=PlacementTarget, RelativeSource={x:Static RelativeSource.Self}}">
                                        <TextBlock Text="{Binding Tag.Comments}"/>
                                    </ToolTip>
                                </Button.ToolTip>
                            </Button>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView >
