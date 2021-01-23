    <ComboBox.Resources>
                                <staticData:SelectedPeriodConverter  x:Key="SelectedPeriodConverter"/>
                                <Style TargetType="{x:Type  ComboBoxItem}">
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding Path=Content, RelativeSource={RelativeSource Self}, Converter={StaticResource SelectedPeriodConverter}}" Value="True">
                                            <Setter Property="IsSelected" Value="True"/>
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </ComboBox.Resources>
