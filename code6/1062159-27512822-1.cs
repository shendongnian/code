    <telerik:GridViewDataColumn.CellTemplate>
        <DataTemplate>
            <StackPanel ...>
                <TextBlock Text="{Binding Path=Name}">
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="MouseLeftButtonDown">
                            <ei:CallMethodAction TargetObject="{Binding RelativeSource={RelativeSource AncestorType=telerik:RadTreeListView},Path=DataContext}"
                                                 MethodName="OnMouseLeftButtonDown" />
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                </TextBlock> 
            </StackPanel>
        </DataTemplate>
    </telerik:GridViewDataColumn.CellTemplate>
