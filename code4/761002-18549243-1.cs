        <DataTemplate DataType="local:Item">
            <!--<TextBox IsEnabled="{Binding ElementName=chkValue11, Path=IsChecked}" Text="{Binding Path=Value1, Mode=TwoWay}"/>-->
            <TextBox Text="{Binding Path=Value1, Mode=TwoWay}">
                <TextBox.IsEnabled>
                    <MultiBinding Converter="{StaticResource convAnd}">
                        <Binding ElementName="chkValue11" Path="IsChecked"/>
                        <Binding Path="IsRowChecked"/>
                    </MultiBinding>
                </TextBox.IsEnabled>
            </TextBox>
        </DataTemplate>
