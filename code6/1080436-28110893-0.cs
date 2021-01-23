    <ItemsControl ItemsSource="{Binding ConditionList}" AlternationCount="{Binding ConditionList.Count}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <WrapPanel>
                    <TextBlock Text="{Binding NodeData}" Name="TxtNodeData">
                        <TextBlock.Style>
                            <Style TargetType="{x:Type TextBlock}">
                                <Style.Triggers>
                                    <DataTrigger 
                                        Binding="{Binding 
                                            RelativeSource={RelativeSource AncestorType={x:Type ContentPresenter}}, 
                                            Path=(ItemsControl.AlternationIndex)}" 
                                        Value="1">
                                        <Setter Property="Visibility" Value="Collapsed"/>
                                    </DataTrigger>
                                </Style.Triggers>
                            </Style>
                        </TextBlock.Style>
                    </TextBlock>
                    <!-- other controls -->
                </WrapPanel>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
