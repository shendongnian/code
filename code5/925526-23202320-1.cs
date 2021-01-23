    <Window.Resources>
        <Style x:Key="MyButtonStyle" TargetType="{x:Type Button}">
            <Setter Property="IsEnabled" Value="True"/>
            <Style.Triggers>
                <DataTrigger Binding="{Binding Path=SelectedItem, ElementName=comboBox1}" Value="{x:Null}">
                    <Setter Property="UIElement.IsEnabled" Value="False"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    
    <Grid>
        <ComboBox Name="comboBox1">
            <ComboBoxItem>One</ComboBoxItem>
            <ComboBoxItem>Two</ComboBoxItem>
            <ComboBoxItem>Three</ComboBoxItem>
        </ComboBox>
    
        <Button Style="{StaticResource MyButtonStyle}" Name="myButton" Content="Push me"/>
    </Grid>
