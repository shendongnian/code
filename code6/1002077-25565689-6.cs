                <ContentControl Content="{Binding YourProperty, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
                    <ContentControl.Resources>
                        <Style TargetType="ContentControl">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding Path=YourProperty,Converter={flowMathTest:TypeOfConverter}}" Value="{x:Type system:DateTime}">
                                    <Setter Property="ContentTemplate">
                                        <Setter.Value>
                                            <DataTemplate>
                                                <DatePicker SelectedDate="{Binding Content, RelativeSource={RelativeSource AncestorType=ContentControl}, UpdateSourceTrigger=PropertyChanged}"/>
                                            </DataTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger>
                                <DataTrigger Binding="{Binding Path=YourProperty,Converter={flowMathTest:TypeOfConverter}}" Value="{x:Type system:String}">
                                    <Setter Property="ContentTemplate">
                                        <Setter.Value>
                                            <DataTemplate>
                                                <TextBox Text="{Binding Content, RelativeSource={RelativeSource AncestorType=ContentControl}, UpdateSourceTrigger=PropertyChanged}"/>
                                            </DataTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </ContentControl.Resources>
                </ContentControl>
