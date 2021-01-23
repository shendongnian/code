    <Window.Resources>
        <Style TargetType="TextBox" x:Key="enableDisableStyle">
            <Style.Triggers>
                <DataTrigger Binding="{Binding IsChecked, ElementName=disabledOne}" Value="True">
                    <Setter Property="IsEnabled" Value="False" />
                </DataTrigger>
                <DataTrigger Binding="{Binding IsChecked, ElementName=disabledTwo}" Value="True">
                    <Setter Property="IsEnabled" Value="False" />
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <StackPanel>
        <RadioButton GroupName="group" x:Name="enabledOne">Enabled one</RadioButton>
        <RadioButton GroupName="group" x:Name="enabledTwo">Enabled two</RadioButton>
        <RadioButton GroupName="group" x:Name="disabledOne">Disabled one</RadioButton>
        <RadioButton GroupName="group" x:Name="disabledTwo">Disabled two</RadioButton>
        <TextBox Text="Test" Style="{StaticResource enableDisableStyle}" />
    </StackPanel>
