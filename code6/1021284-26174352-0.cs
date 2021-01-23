    <ItemsControl ItemsSource="{Binding Logged}"
                  Style="{StaticResource Users}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <WrapPanel Orientation="Horizontal"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <DockPanel Margin="4,0,0,0" Width="100" Height="100">
                    <DockPanel.Background>
                        <ImageBrush ImageSource="{Binding ThumbLoc}" />
                    </DockPanel.Background>
                    <Label>
                        <Label.Content>
                            <TextBlock>
                               <TextBlock.Text>
                                  <MultiBinding StringFormat="{}{0} {1}">
                                     <Binding Path="FirstName" />
                                     <Binding Path="LastName" />
                                  </MultiBinding>
                               </TextBlock.Text>
                            </TextBlock>
                        </Label.Content>
                    </Label>
                </DockPanel>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
