    <Style TargetType="controls:MessageControl">
        ...
        <Style.Triggers>
            <DataTrigger Binding="{Binding Message.MessageType,
                                   RelativeSource={RelativeSource Self}}"
                         Value="{x:Static classes:MessageTypes.Error}">
                <Setter Property="Background" Value="Red" />
            </DataTrigger>
        </Style.Triggers>
    </Style>
