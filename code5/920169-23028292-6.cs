    <Window.Resources>
        <Style x:Key="ImgToggleButton" TargetType="ToggleButton">
            <Setter Property="ContentTemplate">
                <Setter.Value>
                    <DataTemplate>
                        <Image Stretch="Uniform" Source="{Binding Content,RelativeSource={RelativeSource TemplatedParent}}"></Image>
                    </DataTemplate>
                </Setter.Value>
            </Setter>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ToggleButton">
                        <Grid x:Name="GD" Background="White">
                            <ContentPresenter></ContentPresenter>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <Trigger  Property="IsChecked" Value="True">
                                <Setter Property="ContentTemplate">
                                    <Setter.Value>
                                        <DataTemplate>
                                            <Image Stretch="Uniform" Source="{Binding Path=Tag, RelativeSource={RelativeSource AncestorType=ToggleButton}}"></Image>
                                        </DataTemplate>
                                    </Setter.Value>
                                </Setter>
                            </Trigger>
                            <Trigger Property="IsChecked" Value="False">
                                <Setter TargetName="GD" Property="Background" Value="White"/>
                            </Trigger>
                            <Trigger Property="IsMouseOver" Value="True">
                                <!-- Nothing so we have no change-->
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
    <ToggleButton x:Name="allTestsToggleButton" Content="imag2.jpg" Tag="imag1.jpg" Style="{DynamicResource ImgToggleButton}" ClickMode="Press"   Grid.Row="2" Grid.Column="3" Grid.ColumnSpan="5"/>
