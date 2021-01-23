    <Style TargetType="{x:Type itvw:ItemView}">
    <Setter Property="Focusable" Value="True"/>
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="{x:Type itvw:ItemView}">
                <i:Interaction.Triggers>
                    <i:EventTrigger EventName="KeyDown">
                        <cmd:EventToCommand Command="{Binding KeyDownCommand, Mode=OneWay}" PassEventArs="True"/>
                    </i:EventTrigger>
                </i:Interaction.Triggers>
                <Border>
                    <Grid>
                        <TextBox/>
                    </Grid>
                </Border>
                <ControlTemplate.Triggers>
                <!--triggers-->
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
    </Style>
    <Style TargetType="{x:Type itvw:ItemView}">
    <Setter Property="Focusable" Value="True"/>
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="{x:Type itvw:ItemView}">
                <Border>                
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="KeyDown">
                            <cmd:EventToCommand Command="{Binding KeyDownCommand, Mode=OneWay}" PassEventArs="True"/>
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                    <Grid>
                        <TextBox/>
                    </Grid>
                </Border>
                <ControlTemplate.Triggers>
                <!--triggers-->
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
    </Style>
