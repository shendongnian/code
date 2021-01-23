    <ToggleButton>
        <ToggleButton.Style>
            <Style TargetType="ToggleButton">
                <Setter Property="Content" Value="&lt;" />
                <Style.Triggers>
                    <Trigger Property="IsChecked" Value="True">
                        <Setter Property="Content" Value="&gt;" />
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ToggleButton.Style>
    </ToggleButton>
