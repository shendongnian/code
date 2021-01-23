             <Style.Triggers>
                <DataTrigger Binding="{Binding ElementName=SmallImage, Path=IsMouseOver, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" Value="True">
                    <DataTrigger.Setters>
                        <Setter Property="IsOpen" Value="True" />
                    </DataTrigger.Setters>
                </DataTrigger>
                <MultiDataTrigger>
                    <MultiDataTrigger.Conditions>
                        <Condition Binding="{Binding ElementName=SmallImage, Path=IsMouseOver, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" Value="False"/>
                        <Condition Binding="{Binding IsOpen, RelativeSource={RelativeSource Self}}" Value="True"/>
                    </MultiDataTrigger.Conditions>
                    <Setter Property="IsOpen" Value="True" />
                </MultiDataTrigger>
            </Style.Triggers>
