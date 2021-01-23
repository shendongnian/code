           <ContentControl>
                <ContentControl.ContentTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <local:myusercontrol  x:Name="control"/>
                            
                            <ToggleButton Content="click" x:Name="toggleBtn"/>
                        </StackPanel>
                        <DataTemplate.Triggers>
                            <Trigger Property="IsChecked" Value="false"  SourceName="toggleBtn">
                                <Setter Property="Visibility" Value="Visible" TargetName="control"/>
                            </Trigger>
                            <Trigger Property="IsChecked" Value="true" SourceName="toggleBtn">
                                <Setter Property="Visibility" Value="Collapsed" TargetName="control"/>
                            </Trigger>
                        </DataTemplate.Triggers>
                    </DataTemplate>
                </ContentControl.ContentTemplate>
            </ContentControl>
