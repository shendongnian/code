    class StationsComparer: IComparer<StationInfo>
    {
        public int Compare( StationInfo x, StationInfo y )
        {
            int result = x.EnergyConsumption.CompareTo( y.EnergyConsumption );
            if( result == 0 )
                result = y.CurrentEnergyAmount.CompareTo( x.CurrentEnergyAmount );
            
            if( result == 0 )
                result = y.NumRobotNearStation.CompareTo( x.NumRobotNearStation );
            if( result == 0 )
                result = x.NumStationsAround.CompareTo( y.NumStationsAround );
            return result;
        }
    }
