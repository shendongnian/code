    <UserControl x:Class="MyViewer.Views.IconView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:vm="clr-namespace:MyViewer.ViewModels" 
             Tag="{Binding Path=Child, RelativeSource={RelativeSource AncestorType={x:Type ViewBox}}}">
    
    <UserControl.Resources>
        <vm:ViewModelLocator x:Key="Locator" />
    </UserControl.Resources>
    
    <UserControl.DataContext>
        <Binding Source="{StaticResource Locator}" Path="Main" />
    </UserControl.DataContext>
    
    <UserControl.ContextMenu>
        <ContextMenu x:Name="CtContextMenu"
                      DataContext="{Binding Path=PlacementTarget, RelativeSource={RelativeSource Self}}">
            <MenuItem Header="Print Current View"
                      Command="{Binding Path=DataContext.PrintCurrentViewCmd}"
                      CommandParameter="{Binding Path=PlacementTarget.Tag,Element=CtContextMenu}"/>
        </ContextMenu>
    </UserControl.ContextMenu>
    
    <UserControl.Style>
        <Style TargetType="{x:Type UserControl}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type UserControl}" >
                        <Viewbox x:Name="MyViewBox">
                            <ContentControl Name="MyContentControl" Content="{TemplateBinding Content}" />
                        </Viewbox>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </UserControl.Style>
