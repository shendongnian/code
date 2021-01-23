    <UserControl.Resources>
        <converter:BoolToVisibilityConverter x:Key="BoolToVisibilityConverter" />
    </UserControl.Resources>
    <sf:GridTreeColumn MappingName="Readable" PercentWidth="2">
    <sf:GridTreeColumn.StyleInfo>
        <sf:GridStyleInfo CellType="CheckBox" HorizontalAlignment="Center"   
     IsThreeState="False" IsEnabled="{Binding Readable, Converter={StaticResource  
     BoolToVisibilityConverter}}"/>
     </sf:GridTreeColumn.StyleInfo>
     </sf:GridTreeColumn>
     <sf:GridTreeColumn MappingName="Writable" PercentWidth="2">
     <sf:GridTreeColumn.StyleInfo>
     <sf:GridStyleInfo CellType="CheckBox" HorizontalAlignment="Center" 
     IsThreeState="False" IsEnabled="{Binding Writable, Converter={StaticResource   
     BoolToVisibilityConverter}}"/>
     </sf:GridTreeColumn.StyleInfo>
     </sf:GridTreeColumn>
