    <Menu>
        <Menu.Resources>
            <ControlTemplate x:Key="ModifiedTemplate" TargetType="ButtonBase">
                <Border BorderThickness="{TemplateBinding Border.BorderThickness}"
                        BorderBrush="{TemplateBinding Border.BorderBrush}"
                        Background="{TemplateBinding Panel.Background}"
                        Name="border"
                        SnapsToDevicePixels="True">
                    <ContentPresenter RecognizesAccessKey="True"
                                        Content="{TemplateBinding ContentControl.Content}"
                                        ContentTemplate="{TemplateBinding ContentControl.ContentTemplate}"
                                        ContentStringFormat="{TemplateBinding ContentControl.ContentStringFormat}"
                                        Name="contentPresenter"
                                        Margin="{TemplateBinding Control.Padding}"
                                        HorizontalAlignment="{TemplateBinding Control.HorizontalContentAlignment}"
                                        VerticalAlignment="{TemplateBinding Control.VerticalContentAlignment}"
                                        SnapsToDevicePixels="{TemplateBinding UIElement.SnapsToDevicePixels}"
                                        Focusable="False" />
                </Border>
                <ControlTemplate.Triggers>
                    <Trigger Property="Button.IsDefaulted" Value="True">
                        <Setter Property="Border.BorderBrush" TargetName="border">
                            <Setter.Value>
                                <DynamicResource ResourceKey="{x:Static SystemColors.HighlightBrushKey}" />
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                    <Trigger Property="ToggleButton.IsChecked" Value="True">
                        <Setter Property="Panel.Background" TargetName="border">
                            <Setter.Value>
                                <SolidColorBrush>#FFBCDDEE</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                        <Setter Property="Border.BorderBrush" TargetName="border">
                            <Setter.Value>
                                <SolidColorBrush>#FF245A83</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                    <Trigger Property="UIElement.IsEnabled" Value="False">
                        <Setter Property="Panel.Background" TargetName="border">
                            <Setter.Value>
                                <SolidColorBrush>#FFF4F4F4</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                        <Setter Property="Border.BorderBrush" TargetName="border">
                            <Setter.Value>
                                <SolidColorBrush>#FFADB2B5</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                        <Setter Property="TextElement.Foreground" TargetName="contentPresenter">
                            <Setter.Value>
                                <SolidColorBrush>#FF838383</SolidColorBrush>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Menu.Resources>
        <Button Template="{StaticResource ModifiedTemplate}">
            <Button.Background>
                <ImageBrush ImageSource="Images/Menu_Drawings.png"/>
            </Button.Background>
        </Button>
    </Menu>
