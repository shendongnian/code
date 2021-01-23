       <StackPanel>
            <ComboBox x:Name="cmbTargetType" SelectionChanged="cmbTargetType_SelectionChanged">
                <ComboBoxItem Content="Material"/>
                <ComboBoxItem Content="ProductPart"/>
            </ComboBox >
            <ComboBox x:Name="cmbTarget">
                <ComboBox.Style>
                    <Style TargetType="{x:Type ComboBox}">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding Text, ElementName=cmbTargetType}" Value="Material">
                                <Setter Property="ItemsSource" Value="{Binding DataContext.MaterialListViewModel.MaterialViewModels.AllMaterials, RelativeSource={RelativeSource AncestorType=Window}}"></Setter>
                            </DataTrigger>
                            <DataTrigger Binding="{Binding Text, ElementName=cmbTargetType}" Value="ProductPart">
                                <Setter Property="ItemsSource" Value="{Binding DataContext.ProductViewModel.ProductPartViewModels.AllProductParts, RelativeSource={RelativeSource AncestorType=Window}}"></Setter>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </ComboBox.Style>
            </ComboBox>
        </StackPanel>
