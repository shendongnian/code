                <telerik:RadGridView x:Name="InvoicesGridView"
                                     ItemsSource="{Binding InvoicesForView}" DataContext="{Binding }"
                                     ShowGroupPanel="False" Style="{StaticResource TransparentScrollBarStyle}"
                                     RowIndicatorVisibility="Collapsed" 
                                     TextElement.Foreground="White"
                                     TextElement.FontSize="12" 
                                     FontWeight="Normal" RowDetailsVisibilityMode="VisibleWhenSelected"
                                     AutoGenerateColumns="False" SelectionMode="Multiple"
                                     ShowColumnHeaders="True" RowHeight="24"
                                     CanUserSelect="True" GroupRenderMode="Flat"
                                     ScrollViewer.VerticalScrollBarVisibility="Visible"
                                     ScrollViewer.CanContentScroll="True" ColumnWidth="*"
                                     VirtualizingStackPanel.VirtualizationMode="Standard"
                                     telerik:GridViewVirtualizingPanel.IsVirtualizing="False" EnableRowVirtualization="False"
                                      CanUserResizeColumns="False">
                    <telerik:RadGridView.Columns>
                        <telerik:GridViewToggleRowDetailsColumn />
						<-- Other columns -->
                    </telerik:RadGridView.Columns>
                    <telerik:RadGridView.RowDetailsTemplate>
                        <DataTemplate>
                            <Grid Background="#f8f8f8" TextElement.Foreground="Black" TextElement.FontWeight="Normal" TextElement.FontStyle="Normal" Margin="-1,0" MinHeight="20">
                                <telerik:RadTabControl >
                                    <telerik:RadTabItem DataContext="{Binding}"/>
                                    <i:Interaction.Behaviors>
                                        <behaviors:RadTabControlTabChangeCommandBehavior>
                                            <behaviors:RadTabControlTabChangeCommandBehavior.TabChangeCommands>
                                                <behaviors:TabChangeCommand TabIndex="0" Command="{Binding Path=DataContext.LoadInvoice, Source={StaticResource ViewContext}}"/>
                                            </behaviors:RadTabControlTabChangeCommandBehavior.TabChangeCommands>
                                        </behaviors:RadTabControlTabChangeCommandBehavior>
                                    </i:Interaction.Behaviors>
                                </telerik:RadTabControl>
                                <-- Other stuff -->
                    </telerik:RadGridView.RowDetailsTemplate>
                </telerik:RadGridView>
