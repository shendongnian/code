               <Style TargetType="ComboBox">
                    <Setter Property="IsEnabled" Value="True" />
                    <Style.Triggers>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding}" Value="Ferrai"/>
                                <Condition Binding="{Binding Path=DataContext.IsOptionEnable, RelativeSource={RelativeSource AncestorType=ComboBox}}" Value="False" />
                            </MultiDataTrigger.Conditions>
                            <MultiDataTrigger.Setters>
                                <Setter Property="IsEnabled" Value="False" />
                            </MultiDataTrigger.Setters>
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
