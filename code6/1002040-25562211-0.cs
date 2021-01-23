     <Button Content="0">
            <Button.Style>
                <Style TargetType="Button">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding RelativeSource={RelativeSource Self},Path=Content}" Value="0">
                            <Setter Property="Background" Value="Gray"/>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding RelativeSource={RelativeSource Self},Path=Content}" Value="1">
                            <Setter Property="Background" Value="Yellow"/>
                        </DataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=Content}" Value="1"/>
                                <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=YourDP}" Value="YourValue"/>
                            </MultiDataTrigger.Conditions>
                            <MultiDataTrigger.Setters>
                                <Setter Property="Background" Value="Red"/>
                            </MultiDataTrigger.Setters>
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
