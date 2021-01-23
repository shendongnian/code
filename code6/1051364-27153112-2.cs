    <?xml version="1.0" encoding="utf-16"?>
    <ControlTemplate TargetType="CheckBox" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" xmlns:s="clr-namespace:System;assembly=mscorlib" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" xmlns:mwt="clr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero">
        <BulletDecorator Background="#00FFFFFF" SnapsToDevicePixels="True">
            <BulletDecorator.Bullet>
                <mwt:BulletChrome Background="{TemplateBinding Panel.Background}" BorderBrush="{TemplateBinding Border.BorderBrush}" RenderMouseOver="{TemplateBinding UIElement.IsMouseOver}" RenderPressed="{TemplateBinding ButtonBase.IsPressed}" IsChecked="{TemplateBinding ToggleButton.IsChecked}" />
            </BulletDecorator.Bullet>
            <ContentPresenter RecognizesAccessKey="True" Content="{TemplateBinding ContentControl.Content}" ContentTemplate="{TemplateBinding ContentControl.ContentTemplate}" ContentStringFormat="{TemplateBinding ContentControl.ContentStringFormat}" Margin="{TemplateBinding Control.Padding}" HorizontalAlignment="{TemplateBinding Control.HorizontalContentAlignment}" VerticalAlignment="{TemplateBinding Control.VerticalContentAlignment}" SnapsToDevicePixels="{TemplateBinding UIElement.SnapsToDevicePixels}" />
        </BulletDecorator>
        <ControlTemplate.Triggers>
            <Trigger Property="ContentControl.HasContent">
                <Setter Property="FrameworkElement.FocusVisualStyle">
                    <Setter.Value>
                        <Style TargetType="IFrameworkInputElement">
                            <Style.Resources>
                                <ResourceDictionary />
                            </Style.Resources>
                            <Setter Property="Control.Template">
                                <Setter.Value>
                                    <ControlTemplate>
                                        <Rectangle Stroke="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}" StrokeThickness="1" StrokeDashArray="1 2" Margin="14,0,0,0" SnapsToDevicePixels="True" />
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </Setter.Value>
                </Setter>
                <Setter Property="Control.Padding">
                    <Setter.Value>
                        <Thickness>4,0,0,0</Thickness>
                    </Setter.Value>
                </Setter>
                <Trigger.Value>
                    <s:Boolean>True</s:Boolean>
                </Trigger.Value>
            </Trigger>
            <Trigger Property="UIElement.IsEnabled">
                <Setter Property="TextElement.Foreground">
                    <Setter.Value>
                        <DynamicResource ResourceKey="{x:Static SystemColors.GrayTextBrushKey}" />
                    </Setter.Value>
                </Setter>
                <Trigger.Value>
                    <s:Boolean>False</s:Boolean>
                </Trigger.Value>
            </Trigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>
