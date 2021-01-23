    <MenuItem Header="No items!" IsEnabled="False">
       <MenuItem.Style>
          <Style TargetType="{x:Type MenuItem}">
             <Setter Property="Visibility" Value="Collapsed" />
             <Style.Triggers>
                <DataTrigger Binding="{Binding Source={StaticResource IndexViewModel}, Path=Indexes.Count}" Value="0">
                   <Setter Property="Visibility" Value="Visible" />
                </DataTrigger>
             </Style.Triggers>
          </Style>
       </MenuItem.Style>
    </MenuItem>
