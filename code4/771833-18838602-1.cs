    <TabControl ItemsSource="{Binding Path=Exercises}" DisplayMemberPath="ExerciseName">
                    <TabControl.ContentTemplate>
                        <DataTemplate>
                                <DataGrid ItemsSource="{Binding Path=Sets}" AutoGenerateColumns="False">
                                    <DataGrid.Columns>
                                        <DataGridTextColumn Header="Weight" Binding="{Binding Path=Weight}"/>
                                        <DataGridTextColumn Header="Reps" Binding="{Binding Path=Reps}"/>
                                    </DataGrid.Columns>
                                </DataGrid>
                        </DataTemplate>
                    </TabControl.ContentTemplate>
                </TabControl>
