    <Window.Resources>
            <Style x:Key="{x:Type ListBoxItem}" TargetType="ListBoxItem">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ListBoxItem}">
                            <ToggleButton>
                                <Grid Width="260" Height="58">
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="58"/>
                                        <ColumnDefinition Width="202"/>
                                    </Grid.ColumnDefinitions>
                                    <Image Grid.Column="0" Source="{StaticResource image_resourse}"/>
                                    <Button Grid.Column="1" Click="Button_Click">Button text</Button>
                                </Grid>
                            </ToggleButton>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Window.Resources>
    <Grid>       
            <ListBox >
                <ListBoxItem>0ABC</ListBoxItem>
                <ListBoxItem>1ABC</ListBoxItem>
                <ListBoxItem>2ABC</ListBoxItem>
            </ListBox>
    </Grid>
