    <ListView x:Name="ServerListView" Height="200" ItemsSource="{Binding Servers, UpdateSourceTrigger=PropertyChanged, Mode=OneWay}">
                <ListView.InputBindings>
                    <MouseBinding  MouseAction="LeftDoubleClick"   Command="{Binding ElementName=ServerListView, Path=DataContext.ListViewItemDoubleClickedCommand}" CommandParameter="{Binding}"   />
                    <MouseBinding  MouseAction="LeftClick"   Command="{Binding ElementName=ServerListView, Path=DataContext.SomeOtherOrSameCommand}" CommandParameter="{Binding}"   />
                </ListView.InputBindings>
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header="Dienstname" DisplayMemberBinding="{Binding ServiceName}" />
                        <GridViewColumn Header="Servername" DisplayMemberBinding="{Binding HostName}" />
                        <GridViewColumn Header="IP" DisplayMemberBinding="{Binding IpAddress}" />
                    </GridView>
                </ListView.View>
            </ListView>
