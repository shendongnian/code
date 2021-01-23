        public bool EnableGrid 
        {
            get 
              { 
                 return this.SelectedItem == null ? false : true;
              }
        }
    <Grid Grid.Row="2" IsEnabled="{Binding EnableGrid}">
         <my:ProductsHistoryDetailView />
    </Grid>
