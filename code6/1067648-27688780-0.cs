      <ComboBox>
            <ComboBox.ItemTemplate>
                <DataTemplate >
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="Default: " Name="txtSelected" Visibility="Collapsed"/>
                        <TextBlock Text="{Binding}"/>
                    </StackPanel>
                    <DataTemplate.Triggers>
                        <DataTrigger Binding="{Binding IsSelected, RelativeSource={RelativeSource AncestorType=ComboBoxItem}}" Value="True">
                            <Setter TargetName="txtSelected" Property="Visibility" Value="Visible"/>
                        </DataTrigger>
                    </DataTemplate.Triggers>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
