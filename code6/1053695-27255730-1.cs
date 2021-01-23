    <ListBox>
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Button>
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="Click">
                            <ei:CallMethodAction 
                                TargetObject="{Binding RelativeSource={RelativeSource AncestorType=ListBox}, Path=DataContext.SomeCommand}" 
                                MethodName="HandleButtonClick" />
                        </i:EventTrigger EventName="Click">
                    </i:Interaction.Triggers>
                </Button>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
