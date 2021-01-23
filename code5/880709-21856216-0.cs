    <TextBox x:Name="TextBoxA" />
    <TextBox x:Name="TextBoxB" />
            
    <Button x:Name="ButtonC">
        <Button.Style>
            <Style TargetType="Button">
                <Style.Triggers>
                    <MultiDataTrigger>
                        <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding Text, ElementName=TextBoxA}" Value=""/>
                            <Condition Binding="{Binding Text, ElementName=TextBoxB}" Value=""/>
                        </MultiDataTrigger.Conditions>
                        <Setter Property="IsEnabled" Value="False" />
                    </MultiDataTrigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
    </Button>
