       <Style TargetType="{x:Type Button}"  x:Key="LinkButton">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Border x:Name="Overlay" CornerRadius="2">
                        <Image x:Name="Enabled" Source="{StaticResource EnabledImg}"/>
                        <Image x:Name="Disabled" Source="{StaticResource DisabledImg}" Visibility="Collapsed"/>
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsEnabled" Value="False">
                           <Setter TargetName="Disabled" Property="Visibility" Value="Visible"/>
                           <Setter TargetName="Enabled" Property="Visibility" Value="Collapsed"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
