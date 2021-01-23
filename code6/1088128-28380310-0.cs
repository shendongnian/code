    List<POSPromotionalMaster> finallist = new List<POSPromotionalMaster>();
    for (int p = 0; p < poscodelength; p++) {
        for (int d = 0; d < dayslength; d++) {
            for (int i = 0; i < itemcodelength; i++ ) {
                var posprommasters = new POSPromotionalMaster();
                ...
                finallist.Add(posprommasters);
            }
        }
    }
