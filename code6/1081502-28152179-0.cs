     <ItemsControl ItemsSource="{Binding Path=MyObservableCollection}" >
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <WrapPanel>
                                <Button Content="{Binding}"
                                        Command="{Binding Path=DataContext.DeleteCondition, RelativeSource={RelativeSource AncestorType=AncestorWithYourViewModelAsDataContext}}" 
                                        CommandParameter="{Binding}" />
                            </WrapPanel>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
   
