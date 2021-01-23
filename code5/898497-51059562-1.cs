    <UserControl.Resources>
        <sys:Double x:Key="BusinessRowHeight">22</sys:Double>
        <local:LineMultiplierConverter x:Key="LineXConverter" BaseValue="{StaticResource BusinessRowHeight}" />
    </UserControl.Resources>
    <ItemsControl Grid.Row="1" ItemsSource="{Binding CarBusiness}" Margin="0 5 0 0">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <Canvas/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Line StrokeThickness="1" Stroke="LightGray"  
                        X1="0" 
                        Y1="{Binding RelativeSource={RelativeSource Self}, Converter={StaticResource LineXConverter}}" 
                        X2="{Binding RelativeSource={RelativeSource AncestorType=ItemsControl, Mode=FindAncestor}, Path=ActualWidth}" 
                        Y2="{Binding RelativeSource={RelativeSource Self}, Converter={StaticResource LineXConverter}}"/>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
