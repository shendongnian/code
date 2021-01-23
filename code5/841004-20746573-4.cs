        public bool IsGridEnabled
        {
            get 
              { 
                 return this.SelectedItem != null;
              }
        }
    <Grid Grid.Row="2" IsEnabled="{Binding IsGridEnabled}">
         <my:ProductsHistoryDetailView />
    </Grid>
