    <Window.Resources>
        <Style TargetType="{x:Type CheckBox}" x:Key="myCheckboxStyle">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type CheckBox}">
                        <StackPanel Orientation="Horizontal">
                            <Image x:Name="checkboxImage" Source="normal.png" Width="32"/>
                            <ContentPresenter/>
                        </StackPanel>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsChecked" Value="True">
                                <Setter TargetName="checkboxImage" Property="Source" Value="checked.png"/>
                            </Trigger>
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <Condition Property="IsMouseOver" Value="True"/>
                                    <Condition Property="IsChecked" Value="False"/>
                                </MultiTrigger.Conditions>
                                <Setter TargetName="checkboxImage" Property="Source" Value="hover.png"/>
                            </MultiTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
