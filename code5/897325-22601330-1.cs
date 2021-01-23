        <Style
            TargetType="ListBox">
            <Setter
                Property="Template">
                <Setter.Value>
                    <ControlTemplate
                        TargetType="{x:Type ListBox}">
                        <Border
                            x:Name="Bd"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="{TemplateBinding BorderThickness}"
                            Background="{TemplateBinding Background}"
                            Padding="0"
                            SnapsToDevicePixels="true">
                            <ScrollViewer
                                Focusable="false"
                                Padding="{TemplateBinding Padding}">
                                <ItemsPresenter
                                    SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" />
                            </ScrollViewer>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger
                                Property="IsEnabled"
                                Value="false">
                                <Setter
                                    Property="Background"
                                    TargetName="Bd"
                                    Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}" />
                            </Trigger>
                            <Trigger
                                Property="IsGrouping"
                                Value="true">
                                <Setter
                                    Property="ScrollViewer.CanContentScroll"
                                    Value="false" />
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
