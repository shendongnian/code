                  <ContentControl>
                        <ContentControl.Style>
                            <Style TargetType="ContentControl">
                                <Setter Property="Content" Value="{StaticResource action_message}"/>
                                <Style.Triggers>
                                    <Trigger Property="IsMouseOver" Value="true">
                                        <Setter Property="Content" Value="{StaticResource action_message_focus}"/>
                                    </Trigger>
                                </Style.Triggers>
                            </Style>
                        </ContentControl.Style>
                    </ContentControl>
