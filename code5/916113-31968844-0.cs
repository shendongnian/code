    <UserControl.Resources>
        <ui:ErrorCollectionConverter x:Key="ErrorCollectionConverter"></ui:ErrorCollectionConverter>
        <Style TargetType="TextBox">
            <Style.Triggers>
                <Trigger Property="Validation.HasError" Value="True">
                    <Setter Property="ToolTip"
                        Value="{Binding RelativeSource={RelativeSource Self},  Path=(Validation.Errors), Converter={StaticResource ErrorCollectionConverter}}">
                    </Setter>
                </Trigger>
            </Style.Triggers>
        </Style>
    </UserControl.Resources>
