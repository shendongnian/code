     <toolkit:ListPicker Width="220" Name="monthCat" VerticalAlignment="Center" Height="58"  ExpansionMode="FullScreenOnly">
                                                    <toolkit:ListPicker.ItemTemplate>
                                                        <DataTemplate>
                                                            <StackPanel>
                                                                <TextBlock Text="{Binding}"/>
                                                            </StackPanel>
                                                        </DataTemplate>
                                                    </toolkit:ListPicker.ItemTemplate>
                                                    <toolkit:ListPicker.FullModeHeader >
                                                        <DataTemplate>
                                                            <TextBlock Text="{Binding}" FontSize="28"/>
                                                        </DataTemplate>
                                                    </toolkit:ListPicker.FullModeHeader>
                                                </toolkit:ListPicker>   
