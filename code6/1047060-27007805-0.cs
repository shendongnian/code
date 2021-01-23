    <ItemsControl x:Name="ic">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Ellipse StrokeThickness="{Binding Thickness}" Width="10" Height="10" Stroke="{Binding Fill}" />
                    <Ellipse.RenderTransform>
                        <TranslateTransform X="{Binding Left}" Y="{Binding Top}">
                            
                        </TranslateTransform>
                    </Ellipse.RenderTransform>
                </Ellipse>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
