            <Style TargetType="Control" x:Key="ErrorToolTip">
            <Style.Resources>
                <Style TargetType="ListBoxItem">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate>
                                <TextBlock Text="{Binding ErrorContent.ErrorMessage}"
                                           Background="Transparent">
                                    <TextBlock.Style>
                                        <Style TargetType="TextBlock">
                                            <Setter Property="Foreground" Value="Red"/>
                                            <Style.Triggers>
                                                <DataTrigger Binding="{Binding ErrorContent.ErrorSeverity}"
                                                             Value="{x:Static local:ErrorType.Warning}">
                                                    <Setter Property="Foreground" Value="Orange" />
                                                </DataTrigger>
                                            </Style.Triggers>
                                        </Style>
                                    </TextBlock.Style>
                                </TextBlock>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </Style.Resources>
            <Style.Triggers>
                <Trigger Property="Validation.HasError" Value="True">
                    <Setter Property="ToolTip"
                            Value="{Binding RelativeSource={RelativeSource Self}, Path=(Validation.Errors), Converter={StaticResource ErrorCollectionConverter}}">
                    </Setter>
                </Trigger>
            </Style.Triggers>
        </Style>
        <Style TargetType="TextBox" BasedOn="{StaticResource ErrorToolTip}"/>
        <Style TargetType="ComboBox" BasedOn="{StaticResource ErrorToolTip}"/>
