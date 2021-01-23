    <Style x:Key="ToolTipPopUp" TargetType="{x:Type ContentControl}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ContentControl}">
                        <StackPanel Orientation="Horizontal">
                            <StackPanel.ToolTip>
                                <ToolTip Visibility="Hidden" />
                            </StackPanel.ToolTip>
                            <ContentPresenter />
                            <Image Source="/info.png" 
                                   ToolTip="{TemplateBinding ToolTip}"
                                   Height="12"
                                   VerticalAlignment="Top" >
                                <Image.Style>
                                    <Style>
                                        <EventSetter Event="Mouse.MouseEnter" Handler="Show_PopupToolTip" />
                                        <EventSetter Event="Mouse.MouseLeave" Handler="Hide_PopupToolTip"/>
                                    </Style>
                                </Image.Style>
                            </Image>
                        </StackPanel>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
