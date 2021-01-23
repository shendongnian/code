        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationId,ArrivalDate,LeaveDate,CampingSpotId,UserId,PersonsAmount,FacilityType,FacilityPrice")] Reservation reservation, int[] SelectedFacilities) 
        {
            //Instantiate our facilities list!
            reservation.FacilitiesList = new List<Facility>();
            foreach (int facId in SelectedFacilities)
            {
                var facType = _facilityrepository.GetFacilityType(facId);
                var facPrice = _facilityrepository.GetFacilityPricePerDay(facId);
                reservation.FacilitiesList.Add(new Facility { FacilityId = facId, FacilityType = facType, FacilityPrice = facPrice} );
            }
            _reservationrepository.Add(reservation);
            return View() //code omitted 
        }
