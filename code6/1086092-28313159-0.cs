              <Style TargetType="DataGridCell">
                    <Style.Triggers>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsSelected" Value="True" />
                                <Condition Property="IsDropOut" Value="true" />
                            </MultiTrigger.Conditions>
                            <Setter Property="Background" Value="Red" />
                        </MultiTrigger>
                    </Style.Triggers>
                </Style>
