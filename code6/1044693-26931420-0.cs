    <MenuItem ItemsSource="{Binding loadables}" Tag="{Binding load}">
        <MenuItem.Style>
            <Style TargetType="{x:Type MenuItem}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding loadables.Count}" Value="0">
                        <Setter Property="IsEnabled" Value="False"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </MenuItem.Style>
    </MenuItem>
