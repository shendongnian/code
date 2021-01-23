    <TabControl ItemsSource="{Binding Tabs}">
        
        <TabControl.ItemTemplate>
            <DataTemplate>
                
                <TextBlock Text="{Binding TabHeader}">
                    <TextBlock.Style>
                        <Style TargetType="TextBlock">
                            
                            <Setter Property="Foreground" Value="Black"/>
                            
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding IsWorking}" Value="True">
                                    <Setter Property="Foreground" Value="Green"/>
                                </DataTrigger>
                            </Style.Triggers>
                            
                        </Style>
                    </TextBlock.Style>
                </TextBlock>
                
            </DataTemplate>
        </TabControl.ItemTemplate>
        
    </TabControl>
