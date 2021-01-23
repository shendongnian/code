    <ItemsControl ItemsSource="{Binding Path=Items}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <RadioButton GroupName="group">
                        <RadioButton.Template>
                            <ControlTemplate>
                                <Expander Header="{Binding Path=Header}" Content="{Binding Path=Content}" 
                                          IsExpanded="{Binding RelativeSource={RelativeSource Mode=TemplatedParent}, Path=IsChecked}" />
                            </ControlTemplate>
                        </RadioButton.Template>
                    </RadioButton>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
