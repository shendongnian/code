    <ResourceDictionary ... >
    <Style x:Key="CloseButtonStyle" TargetType="{x:Type Button}" >
      ...
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Button}">
                    <Border x:Name="bd" ....>
                    ....
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True" SourceName="bd">
                            <Setter Property="Background" TargetName="bd" Value="{DynamicResource {x:Static SystemColors.ControlLightLightBrushKey}}"/>
                            ... 
                        </Trigger>
                        <Trigger Property="IsPressed" Value="True">
                            <Setter Property="Background" TargetName="bd">
                              ...
                            </Setter>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
