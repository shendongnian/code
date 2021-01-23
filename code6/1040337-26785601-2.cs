    public class Vluchten
    {
        // Existing code here . . .
        // Override the ToString() method
        public override string ToString()
        {
            return string.Format(
                "{0} flight #{1} is heading to {2} carrying {3} passengers out of {4} max.",
                FlightCarrier, FlightNr, Destination, bookedPassagers, maxPassagers);
        }
    }
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // Normally this would be created and populated elsewhere.
        // I've put it here for now because it's simpler for this example
        var vluchtList = new List<Vluchten>
            {
                new Vluchten("flight1", "carrier1", "destination1", 10, 1),
                new Vluchten("flight2", "carrier2", "destination2", 20, 2),
                new Vluchten("flight3", "carrier1", "destination3", 30, 3),
                new Vluchten("flight4", "carrier2", "destination1", 40, 4),
                new Vluchten("flight5", "carrier1", "destination2", 50, 5),
            };
    
        Console.WriteLine("");
        
        // In the real app, where we aren't creating the list above, it's possible
        // that there may be no flights. So if the list is empty (or null) we can
        // tell the user that there is no info (rather than not outputting anything)
        if (vulchtList == null || !vluchtList.Any())
        {
             Console.WriteLine("There is no flight information to display.");
        }
        else
        {
            foreach (Vluchten vluchten in vluchtList)
            {
                Console.WriteLine(vluchten);
            }
        }
    }
