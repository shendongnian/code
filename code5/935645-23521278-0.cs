    <GridViewColumn Width="100" Header="Image">
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <Image Width="16" Height="16" Source="Images\green_tick.jpg">
                    <Image.Style>
                         <Style TargetType="{x:Type Image}">
                            <Setter Property="Visibility" Value="Visible" />
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding ExtractionCompleted}" Value="True">
                                     <Setter Property="Visibility" Value="Hidden" />
                                </DataTrigger>
                            </Style.Triggers>
                         </Style>
                    </Image.Style>
                </Image>
            </DataTemplate>
        </GridViewColumn.CellTemplate>
    </GridViewColumn>
