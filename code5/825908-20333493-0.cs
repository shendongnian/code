     private void LoadJsonData(object sender, RoutedEventArgs e)
        {
            var service = new Service1Client();
            service.getSearchCoordsAsync(new getSearchCoordsRequest(searchBar.Text));
            service.getSearchCoordsCompleted += new EventHandler<getSearchCoordsCompletedEventArgs>(obj_getSearchCoordsCompleted);
        }
        public void obj_getSearchCoordsCompleted(object sender, getSearchCoordsCompletedEventArgs e)
        {
            var response = e.Result.getSearchCoordsResult;
            var pagedResults = JsonConvert.DeserializeObject<ResultSetPager<Place>>(response);
            lstPlaces.ItemsSource = pagedResults.SearchResults;
        }
