    <Style TargetType="{x:Type Button}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Button}">
                    <Border x:Name="Border" CornerRadius="2" BorderThickness="1" Background="{x:Static SystemColors.ControlBrush}" BorderBrush="{x:Static SystemColors.ControlDarkDarkBrush}">
                        <ContentPresenter  Margin="2" HorizontalAlignment="Center" VerticalAlignment="Center" RecognizesAccessKey="True"/>
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsKeyboardFocused" Value="True">
                            <Setter TargetName="Border" Property="BorderBrush" Value="{x:Static SystemColors.ControlBrush}" />
                            <Setter TargetName="Border" Property="BorderBrush" Value="{x:Static SystemColors.ControlDarkDarkBrush}" />
                        </Trigger>
                        <Trigger Property="IsDefaulted" Value="True">
                            <Setter TargetName="Border" Property="BorderBrush" Value="{x:Static SystemColors.ControlBrush}" />
                            <Setter TargetName="Border" Property="BorderBrush" Value="{x:Static SystemColors.ControlDarkDarkBrush}" />
                        </Trigger>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter TargetName="Border" Property="Background" Value="{x:Static SystemColors.ActiveCaptionBrush}" />
                            <Setter TargetName="Border" Property="BorderBrush" Value="{x:Static SystemColors.ControlDarkDarkBrush}" />
                        </Trigger>
                        <Trigger Property="IsPressed" Value="True">
                            <Setter TargetName="Border" Property="Background" Value="{x:Static SystemColors.ActiveCaptionBrush}" />
                            <Setter TargetName="Border" Property="BorderBrush" Value="{x:Static SystemColors.ControlDarkDarkBrush}" />
                        </Trigger>
                        <Trigger Property="IsEnabled" Value="False">
                            <Setter TargetName="Border" Property="Background" Value="#EEEEEE" />
                            <Setter TargetName="Border" Property="BorderBrush" Value="#AAAAAA" />
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
