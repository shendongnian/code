      <Style x:Key="ModelsComboBox" TargetType="ComboBox">
                <Setter Property="ItemContainerStyle">
                    <Setter.Value>
                        <Style TargetType="ComboBoxItem">
                            <Setter Property="IsEnabled" Value="True"/>
                            <Style.Triggers>
                                <MultiDataTrigger>
                                    <MultiDataTrigger.Conditions>
                                        <Condition Binding="{Binding}" Value="Ferrari"/>
                                        <Condition Binding="{Binding Path=DataContext.IsOptionEnable,
                                                   RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ComboBox}}}"
                                                   Value="False"/>
                                    </MultiDataTrigger.Conditions>
                                    <Setter Property="IsEnabled" Value="False"/>
                                </MultiDataTrigger>
                            </Style.Triggers>
                        </Style>
                    </Setter.Value>
                </Setter>
            </Style>
