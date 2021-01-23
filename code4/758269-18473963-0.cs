    <Window.Resources>
            <Style TargetType="{x:Type TabItem}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type TabItem}">
                            <Border>
                                <Grid>
                                    <Grid>
                                        <Border x:Name="border" 
                                                CornerRadius="3,3,0,0"
                                                Background="WhiteSmoke"/>
                                    </Grid>
                                        <ContentPresenter ContentSource="Header"
                                                          HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                                          VerticalAlignment="{TemplateBinding VerticalContentAlignment}" />
                                </Grid>
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsMouseOver"
                                         Value="True">
                                    <Setter TargetName="border"
                                            Property="Background"
                                            Value="LightGray" />
                                </Trigger>
                                <Trigger Property="IsSelected"
                                         Value="True">
                                    <Setter TargetName="border"
                                            Property="Background"
                                            Value="LightGray" />
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Window.Resources>
