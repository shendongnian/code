        public bool EnableGrid 
        {
            get 
              { 
                 return this.SelectedItem != null;
              }
        }
    <Grid Grid.Row="2" IsEnabled="{Binding EnableGrid}">
         <my:ProductsHistoryDetailView />
    </Grid>
