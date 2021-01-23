    <Button x:Name="dumybutton" Content="Click me to see Folders" Background="#FF6E5FCF" Click="dumyclick"/>
    <Grid x:Name="ShowFolders" Background="#FFEA8282">
       <ScrollViewer>
          <ListView x:Name="ViewMusicFolders" Grid.Row="1" Grid.Column="2" VirtualizingStackPanel.VirtualizationMode="Recycling" SelectionMode="None" IsActiveView="True">                                    
             <ListView.ItemsPanel>
                <ItemsPanelTemplate>
                   <WrapGrid Orientation="Horizontal" MaximumRowsOrColumns="2" />
                </ItemsPanelTemplate>
             </ListView.ItemsPanel>
             <ListView.ItemTemplate>
                <DataTemplate>
                   <StackPanel>
                     <TextBlock Text="{Binding strName}" />
                     <TextBlock Text="{Binding strPath}" />
                   </StackPanel>
                </DataTemplate>
             </ListView.ItemTemplate>
          </ListView>
       </ScrollViewer>
    </Grid>
