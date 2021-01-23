        <Viewbox Width="50" x:Name="ActionIconBox1" Height="40.5" >
            <Border BorderThickness="2" BorderBrush="Red">
                <ContentControl>
                    <ContentControl.Style>
                        <Style TargetType="{x:Type ContentControl}">
                            <Setter Property="Content" Value="{StaticResource action_message}"/>
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding RelativeSource={RelativeSource AncestorType=Border,AncestorLevel=1}, Path=IsMouseOver}" Value="True" >
                                    <Setter Property="Content" Value="{StaticResource action_message_focus}"/>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </ContentControl.Style>
                </ContentControl>
            </Border>
        </Viewbox>
