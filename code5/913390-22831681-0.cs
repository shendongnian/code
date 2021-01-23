    <ToggleButton>
        <ToggleButton.Style>
            <Setter Property="Content" Value="&lt;" />
            <Style TargetType="ToggleButton">
                <Style.Triggers>
                    <Trigger Property="IsChecked" Value="True">
                        <Setter Property="Content" Value="&gt;" />
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ToggleButton.Style>
    </ToggleButton>
