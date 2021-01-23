        <ListView>
            <ListView.View>
                <GridView>
                    <GridViewColumn>
                        <GridViewColumn.CellTemplate>
                             <Border Style="{StaticResource borderBase}">
                                 <TextBlock Style="{StaticResource textBlockBase}" Text="{Binding FirstName}" />
                             </Border>
                        </GridViewColumn.CellTemplate>
                        <GridViewColumn.HeaderTemplate>
                            <!--your header template-->
                        </GridViewColumn.HeaderTemplate>
                    </GridViewColumn>
                    <GridViewColumn>
                        <GridViewColumn.CellTemplate>
                             <Border Style="{StaticResource borderBase}">
                                 <TextBlock Style="{StaticResource textBlockBase}" Text="{Binding SecondName}" />
                             </Border>
                        </GridViewColumn.CellTemplate>
                        <GridViewColumn.HeaderTemplate>
                            <!--your header template-->
                        </GridViewColumn.HeaderTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
