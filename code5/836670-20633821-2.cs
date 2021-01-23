    <ListView  x:Name="gridTopics" BorderThickness="2" ItemsSource="{Binding Path=TopicsInfoCollection}" HorizontalAlignment="Left" Margin="91,79,0,0" VerticalAlignment="Top" Height="242" Width="310" BorderBrush="#FF32A3D6"  >
            <ListView.Effect>
                <DropShadowEffect Color="#FF9ADDFB"/>
            </ListView.Effect>
            <ListView.View>
                <GridView >
                    <GridView.Columns>
                        <GridViewColumn  x:Name="colPageNo" DisplayMemberBinding="{Binding PAGENO}" Width="50" Header="Pages" />
                        <GridViewColumn x:Name="colListTopics" Width="241" Header="Associated Topics" >
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <ComboBox x:Name="colTopics"  Width="100" Height="30"  SelectedValue="{Binding SELECTEDTOPICProperty}" Margin="31,333,317,10">
                                    <ComboBoxItem Content="eyteeee"/>
                                    <ComboBoxItem Content="eyteyte"/>
                                    </ComboBox>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                    </GridView.Columns>
                </GridView>
            </ListView.View>
        </ListView>
