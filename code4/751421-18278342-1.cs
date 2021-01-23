    private void deletevehicle(Vehicle v)
    {
        if (v != null)
        {
            //Raise up a progress dialog here
            //I'm assuming that VehicleDB.DeleteVehicle is actually interacting with a service, 
            //or deleting the record from a local sqllite db.
            VehicleDB.DeleteVehicle(v.ID);
            listAdapter = new CustomListAdapter(this);
            //Make the progress Dialog invisible again
        }
    }
