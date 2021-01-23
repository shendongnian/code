    <Grid Background="Black">
        <Grid.Resources>
            <Style TargetType="{x:Type RadioButton}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type RadioButton}">
                            <TextBlock Text="{TemplateBinding Content}">
                                <TextBlock.Style>
                                    <Style TargetType="{x:Type TextBlock}">
                                        <Setter Property="Foreground" Value="White" />
                                        <Style.Triggers>
    <DataTrigger Binding="{Binding IsChecked, RelativeSource={RelativeSource AncestorType={
    x:Type RadioButton}}}" Value="True">
        <Setter Property="Foreground" Value="Gold" />
    </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </TextBlock.Style>
                            </TextBlock>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Grid.Resources>
        <StackPanel Margin="5" Background="{x:Null}">
            <RadioButton Content="1.Video 1." />
            <RadioButton Content="2.Video 2." />
            <RadioButton Content="3.Video 3." />
        </StackPanel>
    </Grid>
