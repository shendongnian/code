        <ListView ...>
            <ListView.Resources>
                <l:TimeStringToIsLateConverter x:Key="TimeColourConverter" />
            </ListView.Resources>
            <ListView.ItemContainerStyle>
                <Style TargetType="{x:Type ListViewItem}">
                    <Setter Property="Height" Value="16" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Time, Converter={StaticResource TimeColourConverter}}" Value="True">
                            <Setter Property="Foreground" Value="Red" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ListView.ItemContainerStyle>
            <ListView.View>
            ...
