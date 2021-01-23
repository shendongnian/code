    <Style x:Key="customItemStyle">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type custom:CommandListBoxItem}">
                    <ToggleButton>
                        <Grid Width="260" Height="58">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="58"/>
                                <ColumnDefinition Width="202"/>
                            </Grid.ColumnDefinitions>
                            <Image Grid.Column="0" Source="{StaticResource image_resourse}"/>
                            <Button Grid.Column="1" Command="{TemplateBinding ButtonCommand}"> Button text </Button>
                        </Grid>
                    </ToggleButton>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
