    <ListView ...>
        ...
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <EventSetter Event="Control.MouseDoubleClick" Handler="VideosView_ItemDoubleClick"/>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding FileExists}" Value="False">
                        <Setter Property="Background" Value="Red" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ListView.ItemContainerStyle>
    </ListView>
