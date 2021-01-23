        <Button.Style>
            <Style TargetType="Button">
                <Style.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                       <Setter Property="ToolTip" Value="{Binding FullToolTip}" />
                       <Setter Property="ToolTipService.IsEnabled" Value="{Binding HasToolTip}" />
                    </Trigger>
                    <Trigger Property="IsMouseOver" Value="False">
                       <Setter Property="ToolTip" Value="{Binding FullToolTip}" />
                       <Setter Property="ToolTipService.IsEnabled" Value="{Binding HasToolTip}" />
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
