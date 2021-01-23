    <TextBlock.Text>
        <Binding ElementName="MainGrid" Path="DataContext"  Converter="{StaticResource TestConverter}">
            <Binding.ConverterParameter>
                   <ItemsControl>
                      <ItemsControl.Items>
                         <Label Content="{Binding ElementName=MainGrid, Path=DataContext}"/>
                         <Label Content="{Binding ElementName=SomeOtherElement, Path=DataContext}"/>
                      </ItemsControl.Items>
                   </ItemsControl>
            </Binding.ConverterParameter>
        </Binding>
    </TextBlock.Text>
