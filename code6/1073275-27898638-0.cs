           <DataGrid x:Name="DgContent" Margin="0,60,-0.4,0" VerticalAlignment="Top" Height="505" ScrollViewer.CanContentScroll="True" ScrollViewer.VerticalScrollBarVisibility="Auto" CanUserAddRows="False" ItemsSource="{Binding}" AutoGenerateColumns="False" ColumnWidth="*">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Title" Binding="{Binding Title}"/>
                <DataGridTextColumn Header="Content Type" Binding="{Binding  Type}"/>
                <DataGridTextColumn Header="Language">
                    <DataGridTextColumn.Binding>
                        <MultiBinding Converter="{StaticResource ResourceKey=Content}">
                            <Binding Path="{x:Static local:MainWindow.cl}"></Binding>
                        </MultiBinding>
                    </DataGridTextColumn.Binding>
                </DataGridTextColumn>
                <DataGridTextColumn Header="Created At" Binding="{Binding CreatedAt}"/>
                <DataGridTemplateColumn Header="Edit/View">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Button Content="Edit/View" Click="View_Click"></Button>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
