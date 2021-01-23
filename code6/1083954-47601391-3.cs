        <ListView x:Name="your_listview"
                  ItemsSource="{Binding Some_Source_Collection}"
                  SelectedIndex="{Binding Some_Int_Variable}">
            <ListView.ItemContainerStyle>
                <Style TargetType="{x:Type ListViewItem}">
                    <Setter Property="BorderBrush" Value="LightGray" />
                    <Setter Property="BorderThickness" Value="0,0,0,1" />
                    <Style.Triggers>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsSelected" Value="true" />
                                <Condition Property="Selector.IsSelectionActive" Value="true" />
                            </MultiTrigger.Conditions>
                            <Setter Property="Foreground" Value="White" />
                            <Setter Property="Template" Value="{StaticResource Selected_Item_Template}" />
                        </MultiTrigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsSelected" Value="true" />
                                <Condition Property="Selector.IsSelectionActive" Value="false" />
                            </MultiTrigger.Conditions>
                            <Setter Property="Foreground" Value="White" />
                            <Setter Property="Template" Value="{StaticResource Selected_Item_Template}" />
                        </MultiTrigger>
                    </Style.Triggers>
                </Style>
            </ListView.ItemContainerStyle>
            <ListView.View>
                <GridView x:Name="your_listview_gridview">
                    <GridViewColumn x:Name="column_1" Header="Name:" Width="100"
                                    DisplayMemberBinding="{Binding Column1}">
                        <GridViewColumn.HeaderContainerStyle>
                            <Style TargetType="{x:Type GridViewColumnHeader}">
                                <Setter Property="HorizontalContentAlignment" Value="Left" />
                                <Setter Property="VerticalContentAlignment" Value="Center" />
                                <Setter Property="IsEnabled" Value="True"/>
                            </Style>
                        </GridViewColumn.HeaderContainerStyle>
                    </GridViewColumn>
                    <GridViewColumn x:Name="column_2" Header="Path:" Width="250"
                                    DisplayMemberBinding="{Binding Column2}">
                        <GridViewColumn.HeaderContainerStyle>
                            <Style TargetType="{x:Type GridViewColumnHeader}">
                                <Setter Property="HorizontalContentAlignment" Value="Left" />
                                <Setter Property="VerticalContentAlignment" Value="Center" />
                                <Setter Property="IsEnabled" Value="True"/>
                            </Style>
                        </GridViewColumn.HeaderContainerStyle>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
