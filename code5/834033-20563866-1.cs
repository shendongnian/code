    <Style TargetType="{x:Type Button}">
        <Setter Property="Button.Background">
            <Setter.Value>
                <ImageBrush ImageSource="Images/Add_16.png" />
            </Setter.Value>
        </Setter>
        <Style.Triggers>
            <Trigger Property="Button.IsPressed" Value="True">
                <Setter Property="Button.Background">
                    <Setter.Value>
                        <ImageBrush ImageSource="Images/Copy_16.png" />
                    </Setter.Value>
                </Setter>
            </Trigger>
        </Style.Triggers>
    </Style>
