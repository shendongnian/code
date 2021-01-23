    <Grid>
      <Grid.Resources>
         <CollectionViewSource x:Key="SortedCollection"
              xmlns:scm="clr-namespace:System.ComponentModel;assembly=WindowsBase"
              Source="{Binding TempSol}">
             <CollectionViewSource.SortDescriptions>
                <scm:SortDescription Direction="Descending"/>
             </CollectionViewSource.SortDescriptions>
         </CollectionViewSource>
      </Grid.Resources>
      <ItemsControl ItemsSource="{Binding Source={StaticResource SortedCollection}}">
         <ItemsControl.ItemTemplate>
            <DataTemplate>
               <TextBlock Text="{Binding }"/>
            </DataTemplate>
         </ItemsControl.ItemTemplate>
       </ItemsControl>
    </Grid>
