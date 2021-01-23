    <ItemsControl DataContext="{Binding [someViewModel]}" BorderBrush="Black" ItemSource="{Binding someList}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <RadioButton Content="{Binding something}" GroupName="radioGroup">
                    <RadioButton.Template>
                        <ControlTemplate TargetType="{x:Type RadioButton}">
                            <Border Background="Green" x:Name="PART_Border">
                                <ContentPresenter/>
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsChecked" Value="True">
                                    <Setter TargetName="PART_Border" Property="Background" Value="Red"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </RadioButton.Template>
                </RadioButton>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
