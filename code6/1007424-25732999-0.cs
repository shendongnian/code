    <Window x:Class="ButtonsStyle.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
            <Style TargetType="{x:Type Button}">
                <Style.Triggers>
                    <Trigger Property="BorderThickness" Value="0">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="Button">
                                    <Border x:Name="Overlay">
                                        <ContentPresenter/>
                                    </Border>
                                    <ControlTemplate.Triggers>
                                        <Trigger Property="IsEnabled" Value="False">
                                            <Setter TargetName="Overlay" Property="Background" Value="Transparent"/>
                                        </Trigger>
                                        <Trigger Property="IsEnabled" Value="True">
                                            <Setter TargetName="Overlay" Property="Background" Value="Transparent"/>
                                        </Trigger>
                                        <Trigger Property="IsMouseOver" Value="True">
                                            <Setter TargetName="Overlay" Property="Background" Value="Red" />
                                        </Trigger>
                                    </ControlTemplate.Triggers>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Window.Resources>
        <StackPanel>
            <Button>Hello</Button>
            <Button BorderThickness="0">World</Button>
        </StackPanel>
    </Window>
