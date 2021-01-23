                <ContentControl Content="{Binding YourProperty}">
                    <ContentControl.Resources>
                        <Style TargetType="ContentControl">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding Path=YourProperty,Converter={local:TypeOfConverter}}" Value="{x:Type system:DateTime}">
                                    <Setter Property="ContentTemplate">
                                        <Setter.Value>
                                            <DataTemplate>
                                                <DatePicker SelectedDate="{Binding Path=.}"/>
                                            </DataTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger>
                                <DataTrigger Binding="{Binding Path=YourProperty,Converter={local:TypeOfConverter}}" Value="{x:Type system:String}">
                                    <Setter Property="ContentTemplate">
                                        <Setter.Value>
                                            <DataTemplate>
                                                <TextBox Text="{Binding Path=.}"/>
                                            </DataTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </ContentControl.Resources>
                </ContentControl>
