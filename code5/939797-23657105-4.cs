    <StackPanel>
        <CheckBox x:Name="IsEnabled" IsChecked="False"></CheckBox>
        <xctk:DateTimePicker IsEnabled="{Binding ElementName=IsEnabled, Path=IsChecked}" Value="1.08.1999">
            <xctk:DateTimePicker.Template>
                <ControlTemplate TargetType="{x:Type xctk:DateTimePicker}">
                    <Border>
                        <Grid>
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="*"/>
                                    <ColumnDefinition Width="Auto"/>
                                </Grid.ColumnDefinitions>
                                <xctk:ButtonSpinner x:Name="PART_Spinner" AllowSpin="{TemplateBinding AllowSpin}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" IsTabStop="False" ShowButtonSpinner="{TemplateBinding ShowButtonSpinner}">
                                    <!--I removed setters of Background and Foreground properties here-->
                                    <xctk:WatermarkTextBox x:Name="PART_TextBox" AcceptsReturn="False" BorderThickness="0" FontWeight="{TemplateBinding FontWeight}" FontStyle="{TemplateBinding FontStyle}" FontStretch="{TemplateBinding FontStretch}" FontSize="{TemplateBinding FontSize}" FontFamily="{TemplateBinding FontFamily}" HorizontalContentAlignment="{TemplateBinding HorizontalContentAlignment}" IsReadOnly="{Binding IsReadOnly, RelativeSource={RelativeSource TemplatedParent}}" MinWidth="20" Padding="0" TextAlignment="{TemplateBinding TextAlignment}" TextWrapping="NoWrap" Text="{Binding Text, RelativeSource={RelativeSource TemplatedParent}}" TabIndex="{TemplateBinding TabIndex}" WatermarkTemplate="{TemplateBinding WatermarkTemplate}" Watermark="{TemplateBinding Watermark}">
                                        <xctk:WatermarkTextBox.Template>
                                            <ControlTemplate TargetType="{x:Type xctk:WatermarkTextBox}">
                                                <Grid>
                                                    <Border x:Name="Border" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" CornerRadius="1"/>
                                                    <Border x:Name="MouseOverVisual" BorderThickness="{TemplateBinding BorderThickness}" CornerRadius="1" Opacity="0">
                                                        <Border.BorderBrush>
                                                            <LinearGradientBrush EndPoint="0,1" StartPoint="0,0">
                                                                <GradientStop Color="#FF5794BF" Offset="0.05"/>
                                                                <GradientStop Color="#FFB7D5EA" Offset="0.07"/>
                                                                <GradientStop Color="#FFC7E2F1" Offset="1"/>
                                                            </LinearGradientBrush>
                                                        </Border.BorderBrush>
                                                    </Border>
                                                    <Border x:Name="FocusVisual" BorderThickness="{TemplateBinding BorderThickness}" CornerRadius="1" Opacity="0">
                                                        <Border.BorderBrush>
                                                            <LinearGradientBrush EndPoint="0,1" StartPoint="0,0">
                                                                <GradientStop Color="#FF3D7BAD" Offset="0.05"/>
                                                                <GradientStop Color="#FFA4C9E3" Offset="0.07"/>
                                                                <GradientStop Color="#FFB7D9ED" Offset="1"/>
                                                            </LinearGradientBrush>
                                                        </Border.BorderBrush>
                                                    </Border>
                                                    <ScrollViewer x:Name="PART_ContentHost" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                                                    <ContentPresenter x:Name="PART_WatermarkHost" ContentTemplate="{TemplateBinding WatermarkTemplate}" Content="{TemplateBinding Watermark}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" IsHitTestVisible="False" Margin="{TemplateBinding Padding}" Visibility="Collapsed" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                                                </Grid>
                                                <ControlTemplate.Triggers>
                                                    <MultiTrigger>
                                                        <MultiTrigger.Conditions>
                                                            <Condition Property="IsFocused" Value="False"/>
                                                            <Condition Property="Text" Value=""/>
                                                        </MultiTrigger.Conditions>
                                                        <Setter Property="Visibility" TargetName="PART_WatermarkHost" Value="Visible"/>
                                                    </MultiTrigger>
                                                    <Trigger Property="IsMouseOver" Value="True">
                                                        <Setter Property="Opacity" TargetName="MouseOverVisual" Value="1"/>
                                                    </Trigger>
                                                    <Trigger Property="IsFocused" Value="True">
                                                        <Setter Property="Opacity" TargetName="FocusVisual" Value="1"/>
                                                    </Trigger>
                                                    <Trigger Property="IsEnabled" Value="False">
                                                        <Setter Property="BorderBrush" TargetName="Border" Value="#FFADB2B5"/>
                                                        <!--I changed Background setter value to White here-->
                                                        <Setter Property="Background" TargetName="Border" Value="White"/>
                                                        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                                                    </Trigger>
                                                </ControlTemplate.Triggers>
                                            </ControlTemplate>
                                        </xctk:WatermarkTextBox.Template>
                                    </xctk:WatermarkTextBox>
                                </xctk:ButtonSpinner>
                                <ToggleButton x:Name="_calendarToggleButton" Background="White" Grid.Column="1" Focusable="False" IsChecked="{Binding IsOpen, RelativeSource={RelativeSource TemplatedParent}}">
                                    <ToggleButton.IsHitTestVisible>
                                        <Binding Path="IsOpen" RelativeSource="{RelativeSource TemplatedParent}">
                                            <Binding.Converter>
                                                <xctk:InverseBoolConverter/>
                                            </Binding.Converter>
                                        </Binding>
                                    </ToggleButton.IsHitTestVisible>
                                    <ToggleButton.IsEnabled>
                                        <Binding Path="IsReadOnly" RelativeSource="{RelativeSource TemplatedParent}">
                                            <Binding.Converter>
                                                <xctk:InverseBoolConverter/>
                                            </Binding.Converter>
                                        </Binding>
                                    </ToggleButton.IsEnabled>
                                    <ToggleButton.Style>
                                        <Style TargetType="{x:Type ToggleButton}">
                                            <Setter Property="Template">
                                                <Setter.Value>
                                                    <ControlTemplate TargetType="{x:Type ToggleButton}">
                                                        <Grid SnapsToDevicePixels="True">
                                                            <xctk:ButtonChrome x:Name="ToggleButtonChrome" CornerRadius="0,2.75,2.75,0" InnerCornerRadius="0,1.75,1.75,0" RenderMouseOver="{TemplateBinding IsMouseOver}" RenderPressed="{TemplateBinding IsPressed}" RenderChecked="{Binding IsOpen, RelativeSource={RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type xctk:DateTimePicker}}}" RenderEnabled="{Binding IsEnabled, RelativeSource={RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type xctk:DateTimePicker}}}">
                                                                <Grid>
                                                                    <Grid.ColumnDefinitions>
                                                                        <ColumnDefinition Width="*"/>
                                                                        <ColumnDefinition Width="Auto"/>
                                                                    </Grid.ColumnDefinitions>
                                                                    <ContentPresenter ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" ContentStringFormat="{TemplateBinding ContentStringFormat}" HorizontalAlignment="Stretch" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="Stretch"/>
                                                                    <Grid x:Name="arrowGlyph" Grid.Column="1" IsHitTestVisible="False" Margin="5">
                                                                        <Path x:Name="Arrow" Data="M0,1C0,1 0,0 0,0 0,0 3,0 3,0 3,0 3,1 3,1 3,1 4,1 4,1 4,1 4,0 4,0 4,0 7,0 7,0 7,0 7,1 7,1 7,1 6,1 6,1 6,1 6,2 6,2 6,2 5,2 5,2 5,2 5,3 5,3 5,3 4,3 4,3 4,3 4,4 4,4 4,4 3,4 3,4 3,4 3,3 3,3 3,3 2,3 2,3 2,3 2,2 2,2 2,2 1,2 1,2 1,2 1,1 1,1 1,1 0,1 0,1z" Fill="Black" Height="4" Width="7"/>
                                                                    </Grid>
                                                                </Grid>
                                                            </xctk:ButtonChrome>
                                                        </Grid>
                                                        <ControlTemplate.Triggers>
                                                            <Trigger Property="IsEnabled" Value="False">
                                                                <Setter Property="Fill" TargetName="Arrow" Value="#FFAFAFAF"/>
                                                            </Trigger>
                                                        </ControlTemplate.Triggers>
                                                    </ControlTemplate>
                                                </Setter.Value>
                                            </Setter>
                                        </Style>
                                    </ToggleButton.Style>
                                </ToggleButton>
                            </Grid>
                            <Popup x:Name="PART_Popup" IsOpen="{Binding IsChecked, ElementName=_calendarToggleButton}" StaysOpen="False">
                                <Border BorderThickness="1" Padding="3">
                                    <Border.BorderBrush>
                                        <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
                                            <GradientStop Color="#FFA3AEB9" Offset="0"/>
                                            <GradientStop Color="#FF8399A9" Offset="0.375"/>
                                            <GradientStop Color="#FF718597" Offset="0.375"/>
                                            <GradientStop Color="#FF617584" Offset="1"/>
                                        </LinearGradientBrush>
                                    </Border.BorderBrush>
                                    <Border.Background>
                                        <LinearGradientBrush EndPoint="0,1" StartPoint="0,0">
                                            <GradientStop Color="White" Offset="0"/>
                                            <GradientStop Color="#FFE8EBED" Offset="1"/>
                                        </LinearGradientBrush>
                                    </Border.Background>
                                    <StackPanel>
                                        <Calendar x:Name="PART_Calendar" BorderThickness="0" DisplayDate="2014-05-14"/>
                                        <xctk:TimePicker x:Name="PART_TimeUpDown" Background="{DynamicResource {x:Static SystemColors.WindowBrushKey}}" ClipValueToMinMax="{Binding ClipValueToMinMax, RelativeSource={RelativeSource TemplatedParent}}" Foreground="{DynamicResource {x:Static SystemColors.WindowTextBrushKey}}" FormatString="{TemplateBinding TimeFormatString}" Format="{TemplateBinding TimeFormat}" Maximum="{Binding Maximum, RelativeSource={RelativeSource TemplatedParent}}" Minimum="{Binding Minimum, RelativeSource={RelativeSource TemplatedParent}}" Value="{Binding Value, RelativeSource={RelativeSource TemplatedParent}}" WatermarkTemplate="{TemplateBinding TimeWatermarkTemplate}" Watermark="{TemplateBinding TimeWatermark}"/>
                                    </StackPanel>
                                </Border>
                            </Popup>
                        </Grid>
                    </Border>
                </ControlTemplate>
            </xctk:DateTimePicker.Template>
        </xctk:DateTimePicker>
    </StackPanel>
