    <ItemsControl ItemsSource="{Binding Path=MyItems}">
       <ItemsControl.ItemsPanel>
           <ItemsPanelTemplate>
               <Grid>
                   <Grid.ColumnDefinitions>
                       <ColumnDefinition/>
                       <ColumnDefinition/>
                       <ColumnDefinition/>
                   </Grid.ColumnDefinitions>
                   <Grid.RowDefinitions>
                       <RowDefinition/>
                       <RowDefinition/>
                       <RowDefinition/>
                   </Grid.RowDefinitions>
               </Grid>
           </ItemsPanelTemplate>
       </ItemsControl.ItemsPanel>
       <ItemsControl.ItemContainerStyle>
           <Style>
               <Setter Property="Grid.Row" Value="{Binding Path=Row}"/>
               <Setter Property="Grid.Column" Value="{Binding Path=Col}"/>
           </Style>
       </ItemsControl.ItemContainerStyle>
    </ItemsControl>
