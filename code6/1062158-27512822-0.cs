    <telerik:GridViewDataColumn.CellTemplate>
        <DataTemplate>
            <StackPanel ...>
                <TextBlock Text="{Binding Path=Name}">
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="MouseLeftButtonDown">
                            <ei:CallMethodAction TargetObject="{Binding ElementName=userControl}"
                                                 MethodName="OnMouseLeftButtonDown" />
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                </TextBlock> 
            </StackPanel>
        </DataTemplate>
    </telerik:GridViewDataColumn.CellTemplate>
