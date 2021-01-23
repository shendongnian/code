      <UserControl.Resources>
            <ResourceDictionary>
                <DataTemplate x:Key="GridViewCellTemplateStyle">
                    <TextBlock Text="{Binding}">
                        <TextBlock.InputBindings>
                            <MouseBinding Gesture="LeftDoubleClick" Command="{Binding DataContext.CommandDoubleClick, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ListView}}}"/>
                        </TextBlock.InputBindings>
                    </TextBlock>
                </DataTemplate>
            </ResourceDictionary>
        </UserControl.Resources>
