     <MenuItem Header="_Recent Studies"
        Height="216" 
        ItemsSource="{Binding RecentFiles}" AlternationCount="{Binding RecentFiles.Count}">
        <MenuItem.Resources>
            <Style TargetType="{x:Type MenuItem}" BasedOn="{StaticResource {x:Type MenuItem}}">
                <Setter Property="Header" >
                    <Setter.Value>
                        <MultiBinding StringFormat="{}{0}. {1}">
                            <Binding Path="(ItemsControl.AlternationIndex)" RelativeSource="{RelativeSource FindAncestor, AncestorType={x:Type MenuItem}}" />
                            <Binding Path="FullFileName"/>
                        </MultiBinding>
                    </Setter.Value>
                </Setter>
            </Style>
        </MenuItem.Resources>
    </MenuItem>
