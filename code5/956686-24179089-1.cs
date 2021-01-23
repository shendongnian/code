    <DataTemplate>
        <RadioButton GroupName="{Binding DataContext.AttrName, RelativeSource={RelativeSource AncestorType=ItemsControl}}"
                     Content="{Binding}"
            <RadioButton.IsChecked>
                <MultiBinding Converter="{StaticResource ElementComparer}" Mode="OneWay">
                    <Binding Path="DataContext.DefaultValue" RelativeSource="{RelativeSource AncestorType=ItemsControl}"/>
                    <Binding />
                </MultiBinding>
            </RadioButton.IsChecked>
