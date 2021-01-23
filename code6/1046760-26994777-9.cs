    <ItemsControl ItemsSource="{Binding VehicleArr}">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <ComboBox ItemsSource="{Binding Options}" 
                                  SelectedItem="{Binding SelectedOption, Mode=TwoWay}"/>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
