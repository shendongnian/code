    <SolidColorBrush x:Key="ListBox.Disabled.Background" Color="#FFFFFFFF" />
    <SolidColorBrush x:Key="ListBox.Disabled.Border" Color="#FFD9D9D9" />
    <Style TargetType="{x:Type local:ButtonListView}" BasedOn="{StaticResource {x:Type ListBox}}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:ButtonListView}">
                    <Border Name="Bd"
                            Background="{TemplateBinding Background}"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="{TemplateBinding BorderThickness}"
                            SnapsToDevicePixels="true"
                            Padding="1">
                        <ScrollViewer Padding="{TemplateBinding Padding}"
                                      Focusable="false">
                            <StackPanel>
                            <ItemsPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                                <Button Content="{TemplateBinding ButtonContent}" Command="{TemplateBinding Command}"></Button>
                            </StackPanel>
                        </ScrollViewer>
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsEnabled" Value="false">
                            <Setter TargetName="Bd" Property="Background" Value="{StaticResource ListBox.Disabled.Background}" />
                            <Setter TargetName="Bd" Property="BorderBrush" Value="{StaticResource ListBox.Disabled.Border}" />
                        </Trigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsGrouping" Value="true" />
                                <Condition Property="VirtualizingPanel.IsVirtualizingWhenGrouping" Value="false" />
                            </MultiTrigger.Conditions>
                            <Setter Property="ScrollViewer.CanContentScroll" Value="false"/>
                        </MultiTrigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
