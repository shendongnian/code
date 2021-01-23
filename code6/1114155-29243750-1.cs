    <ResourceDictionary
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:WpfApplication1">
    
    
        <Style TargetType="{x:Type local:CustomControl1}">
            <Setter Property="ContextMenu">
                <Setter.Value>
                    <ContextMenu>
                        <MenuItem Header="Cut" Command="ApplicationCommands.Cut" />
                        <MenuItem Header="Copy" Command="ApplicationCommands.Copy" />
                        <MenuItem Header="Past" Command="ApplicationCommands.Paste" />
                        <MenuItem Header="Execute MyCommand in CustomControl1"
                                  Command="{Binding RelativeSource={RelativeSource AncestorType=ContextMenu}, Path=PlacementTarget.TemplatedParent.MyCommand}" />
                        <!--In this case, PlacementTarget is "txtBox"
                        This is why we have to find the templated parent of the PlacementTarget because MyCommand is defined in the CustomControl1 code-behind-->
                    </ContextMenu>
                </Setter.Value>
            </Setter>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type local:CustomControl1}">
                        <Grid>
                            <!--Some UI elements-->
                            <TextBox Name="txtBox" ContextMenu="{TemplateBinding ContextMenu}" />
                            <!--Others UI elements-->
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </ResourceDictionary>
