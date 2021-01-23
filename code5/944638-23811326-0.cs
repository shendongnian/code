                    <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type GridViewColumnHeader}">
                            <Grid SnapsToDevicePixels="true">
                                <Border x:Name="HeaderBorder" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="0,1,0,1" Background="{TemplateBinding Background}">
                                    <Grid>
                                        <Grid.RowDefinitions>
                                            <RowDefinition MaxHeight="7"/>
                                            <RowDefinition/>
                                        </Grid.RowDefinitions>
                                        <Rectangle x:Name="UpperHighlight" Fill="#FFE3F7FF" Visibility="Collapsed"/>
                                        <Border Padding="{TemplateBinding Padding}" Grid.RowSpan="2">
                                            <ContentPresenter x:Name="HeaderContent" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="0,0,0,1" RecognizesAccessKey="True" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                                        </Border>
                                    </Grid>
                                </Border>
                                <Border x:Name="HeaderHoverBorder" BorderThickness="1,0,1,1" Margin="1,1,0,0"/>
                                <Border x:Name="HeaderPressBorder" BorderThickness="1,1,1,0" Margin="1,0,0,1"/>
                                <Canvas>
                                    <Thumb x:Name="PART_HeaderGripper" Style="{StaticResource GridViewColumnHeaderGripper}"/>
                                </Canvas>
                            </Grid>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsMouseOver" Value="true">
                                    <Setter Property="Background" TargetName="HeaderBorder" Value="{StaticResource GridViewColumnHeaderHoverBackground}"/>
                                    <Setter Property="BorderBrush" TargetName="HeaderHoverBorder" Value="#FF88CBEB"/>
                                    <Setter Property="Visibility" TargetName="UpperHighlight" Value="Visible"/>
                                    <Setter Property="Background" TargetName="PART_HeaderGripper" Value="Transparent"/>
                                </Trigger>
                                <Trigger Property="IsPressed" Value="true">
                                    <Setter Property="Background" TargetName="HeaderBorder" Value="{StaticResource GridViewColumnHeaderPressBackground}"/>
                                    <Setter Property="BorderBrush" TargetName="HeaderHoverBorder" Value="#FF95DAF9"/>
                                    <Setter Property="BorderBrush" TargetName="HeaderPressBorder" Value="#FF7A9EB1"/>
                                    <Setter Property="Visibility" TargetName="UpperHighlight" Value="Visible"/>
                                    <Setter Property="Fill" TargetName="UpperHighlight" Value="#FFBCE4F9"/>
                                    <Setter Property="Visibility" TargetName="PART_HeaderGripper" Value="Hidden"/>
                                    <Setter Property="Margin" TargetName="HeaderContent" Value="1,1,0,0"/>
                                </Trigger>
                                <Trigger Property="Height" Value="Auto">
                                    <Setter Property="MinHeight" Value="20"/>
                                </Trigger>
                                <Trigger Property="IsEnabled" Value="false">
                                    <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
