    IEnumerable<MasterObsTrip> masterTripList = _obsvMasterRepo.GetObsTrips(vesselName, dateYear, port, obsvCode, obsvTripCode, obsvProgCode, lastModifiedDateYear, lastModifiedBy, statusCode);
            IList<MasterObsTripModel> masterTripModelList = new List<MasterObsTripModel>();
            foreach (MasterObsTrip trip in masterTripList)
                masterTripModelList.Add(new MasterObsTripModel(trip));
       
            CsvFileDescription outputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',', // comma delimited
                FirstLineHasColumnNames = true, // no column names in first record
                FileCultureName = "nl-NL" // use formats used in The Netherlands
            };
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK) {
               Content = new CsvContent<MasterObsTripModel> (outputFileDescription, 
                                                          "ObserverTripList.csv", 
                                                           masterTripModelList);
            }
            return response;
