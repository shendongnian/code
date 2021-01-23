        public async Task<your return type> or Task if return type is void Cordinates()
        {
            if (_geolocator == null)
            {
                _geolocator = new Geolocator();
            }
            this.Status = "Searching..."; // seting status and awaiting your async GetGeoposition
            Geoposition _Position = await locator.GetGeopositionAsync();
            this.Status = "Done"; // after GetGeoposition is finidshed you are here and setting status to done
        }
