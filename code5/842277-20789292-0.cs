     <TabControl Margin="20">
            <TabItem IsEnabled="False" >
                <TabItem.Style>
                    <Style TargetType="TabItem">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate>
                                    <TextBlock Text="My Company" Margin="0,0,5,0"/>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </TabItem.Style>
            </TabItem>
        <TabItem Header="FirstTabITem" IsSelected="True"/>
        <TabItem Header="SecondTabITem" />
      </TabControl>
