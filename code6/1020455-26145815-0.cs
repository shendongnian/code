    <DockPanel Grid.Column="1" Visibility="Hidden">
        <DockPanel.Style>
            <Style TargetType="{x:Type DockPanel}">
                <Style.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Setter Property="Visibility" Value="Visible"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </DockPanel.Style>
   
