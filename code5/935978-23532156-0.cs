    private void UpdateExistLotList()
    {
        using (var db = new DDataContext())
        {
            //Grabs the lot_number column from db that is distinct
            var ExistLot = db.LotInformation.First(l => l.lot_number.Equals(LotNumber));
        }
    }
