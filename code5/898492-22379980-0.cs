     <ItemsControl ItemsSource="{Binding Items}" Name="lista">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Vertical">
                        <TextBlock>
                            <TextBlock.Text>
                                <MultiBinding Converter="{StaticResource converter}">
                                    <Binding Path="."/>
                                    <Binding ElementName="lista" Path="ItemsSource"/>
                                </MultiBinding>
                            </TextBlock.Text>
                        </TextBlock>
                    </StackPanel>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
