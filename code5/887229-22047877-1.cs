    <ItemsControl ItemsSource="{Binding Questions}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <Label Content="{Binding QuestionText}" />
                        <ItemsControl ItemsSource="{Binding Variants}">                              
                            <ItemsControl.ItemTemplate>
                                <DataTemplate>
                                    <RadioButton Content="{Binding VariantText}" IsChecked="{Binding IsChecked}" GroupName="{Binding Group}" />
                                </DataTemplate>                                
                            </ItemsControl.ItemTemplate>                            
                        </ItemsControl>                        
                    </StackPanel>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
