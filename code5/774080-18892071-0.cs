    <Grid>
        <CheckBox x:Name="cbTest1" Margin="12,341,476,5" IsEnabled="{Binding Path=BoolProperty1, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
        <CheckBox x:Name="cbTest3" Margin="74,341,414,5" IsEnabled="{Binding Path=BoolProperty2, Mode=TwoWay }" />
        <CheckBox x:Name="cbTest2" Margin="131,341,359,5" IsEnabled="{Binding Path=BoolProperty3, Mode=TwoWay }" />
        <Button x:Name="btnClick" Click="btnClick_Click" Margin="231,333,29,5" />
    </Grid>
