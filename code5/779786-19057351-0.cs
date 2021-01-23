        <ResourceDictionary>
            <Style x:Key="TestButton" TargetType="Button">
                <Setter Property="Height" Value="30" />
                <Setter Property="Width" Value="30" />
                <Setter Property="Background" Value="Transparent" />
                <Setter Property="Foreground" Value="Green" />
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="Button">
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsMouseOver" Value="True">
                                    <Setter Property="Foreground" Value="Purple" />
                                </Trigger>
                            </ControlTemplate.Triggers>
                            <Grid>
                                <Rectangle Fill="{TemplateBinding Foreground}" />
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ResourceDictionary>
