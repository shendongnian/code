     <Window.Resources>
        <Style x:Key="style" TargetType="{x:Type ComboBoxItem}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ComboBoxItem">
                        <Grid>
                            <Border x:Name="Border" Background="Transparent">
                                <TextBlock FontSize="12" FontFamily="Segoe UI Light">
                            <ContentPresenter></ContentPresenter>
                                </TextBlock>
                            </Border>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <Trigger Property="ComboBoxItem.IsSelected" Value="True">
                                <Setter TargetName="Border" Property="Background" Value="Red"></Setter>
                            </Trigger>
                            <Trigger Property="ComboBoxItem.IsMouseOver" Value="True">
                                <Setter TargetName="Border" Property="Background" Value="LightGray"></Setter>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
    <ComboBox Height="35" Width="200" ItemContainerStyle="{StaticResource style}">
        <ComboBoxItem>Item1</ComboBoxItem>
        <ComboBoxItem>Item2</ComboBoxItem>
    </ComboBox>
