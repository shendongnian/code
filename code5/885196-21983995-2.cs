    <Window.Resources>
            <ControlTemplate x:Key="validationTemplate">
                <DockPanel>
                    <AdornedElementPlaceholder/>
                    <TextBlock Foreground="Red">Invalid value!</TextBlock>
                </DockPanel>
            </ControlTemplate>
    
            <Style x:Key="validationError" TargetType="{x:Type TextBox}">
                <Style.Triggers>
                    <Trigger Property="Validation.HasError" Value="true">
                        <Setter Property="ToolTip" Value="{Binding RelativeSource={x:Static RelativeSource.Self}, Path=(Validation.Errors)[0].ErrorContent}"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Window.Resources>
        
        <Grid>
            <StackPanel>
                <TextBox Validation.ErrorTemplate="{StaticResource validationTemplate}" Style="{StaticResource validationError}" Margin="150">
                    <TextBox.Text>
                        <Binding Path="User.Name" UpdateSourceTrigger="PropertyChanged" >
                            <Binding.ValidationRules>
                                <local:NameLengthRule />
                            </Binding.ValidationRules>
                        </Binding>
                    </TextBox.Text>
                </TextBox>
            </StackPanel>
        </Grid>
