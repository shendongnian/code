    <MenuItem Header="_Recent Studies"  ItemsSource="{Binding RecentFiles}" AlternationCount="{Binding RecentFiles.Count}" HeaderTemplate="{x:Null}">
        <MenuItem.Resources>
            <Style TargetType="{x:Type MenuItem}" BasedOn="{StaticResource {x:Type MenuItem}}">
                <Setter Property="HeaderTemplate" >
                    <Setter.Value>
                        <DataTemplate>
                            <TextBlock>
                                <TextBlock.Text>
                                    <MultiBinding StringFormat="{}{0}. {1}">
                                       <Binding Path="(ItemsControl.AlternationIndex)" RelativeSource="{RelativeSource FindAncestor, AncestorType={x:Type MenuItem}}" />
                                       <Binding Path="FullFileName"/>
                                    </MultiBinding>
                                </TextBlock.Text>
                            </TextBlock>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </MenuItem.Resources>
    </MenuItem>
