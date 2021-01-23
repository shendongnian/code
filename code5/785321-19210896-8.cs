    class VehicleRepository : IEnumerable<Vehicle> {
        List<Vehicle> vehicles;
        public IEnumerator<Vehicle> GetEnumerator() {
            return vehicles.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
    }
