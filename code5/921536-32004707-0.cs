        <TabControl>
            <TabControl.Resources>
                <Style TargetType="{x:Type TabItem}">
                    <Setter Property="HeaderTemplate">
                        <Setter.Value>
                            <DataTemplate>
                                <TextBlock Text="{Binding}" MaxWidth="200" />
                            </DataTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </TabControl.Resources>
        </TabControl>
