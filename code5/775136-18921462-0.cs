    <ListView.Resources>
        <ContextMenu x:Key="ItemContextMenu">
            <MenuItem Header="More Info" Command="{Binding Path=DataContext.MoreInfo, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ListView}}" Background="WhiteSmoke" />
        </ContextMenu>
    </ListView.Resources>
    
    <ListView.ItemContainerStyle>
        <Style TargetType="{x:Type ListViewItem}" >
            <Setter Property="ContextMenu" Value="{StaticResource ItemContextMenu}" />
        </Style>
    </ListView.ItemContainerStyle>
