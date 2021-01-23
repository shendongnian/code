    <cnv:WhiteSpaceConverter x:Key="WhiteSpaceConverter" />
    ...
    <TextBox FontFamily="Consolas" 
                Text="{Binding ViewModelStringProperty, 
                       Mode=TwoWay, 
                       UpdateSourceTrigger=PropertyChanged, 
                       Converter={StaticResource WhiteSpaceConverter}}" 
                >
        <TextBox.CommandBindings>
            <CommandBinding Command="{x:Static ApplicationCommands.Copy}" Executed="TextBox_Copy_Executed" />
        </TextBox.CommandBindings>
    </TextBox>
