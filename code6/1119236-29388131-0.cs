    <Window.Resources>
        <Style x:Key="WrapStyle" TargetType="DataGridCell">
            <Style.Setters>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type DataGridCell}">
                            <TextBox Text="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Content.Text}" TextWrapping="Wrap">
                                <TextBox.ToolTip>
                                    <ToolTip>
                                        <ToolTip.Content>
                                            <TextBlock Text="{Binding Path=Tooltip}"></TextBlock>
                                        </ToolTip.Content>
                                    </ToolTip>
                                </TextBox.ToolTip>
                            </TextBox>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style.Setters>
        </Style>
    </Window.Resources>
