    <UserControl>
        <ScrollViewer>
           <telerik:RadGridView ItemsSource="{Binding}" AutoGenerateColumns="False">
                <telerik:RadGridView.Columns>
                    <telerik:GridViewDataColumn DataMemberBinding="{Binding Section, Mode=TwoWay}"
                                                Header="Seccion" IsFilterable="False" IsVisible="True" />
                    <!-- Additional column definitions. -->
                </telerik:RadGridView.Columns>
            </telerik:RadGridView>
        </ScrollViewer>
    </UserControl>
