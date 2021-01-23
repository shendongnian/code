        public class CompositeViewModel
        {
            public ITest SelectedViewModel { get; set; }
            // Init the VM's and change them at run time ...
        }
        public class TripsResponseTypeViewModel : ITest
        {
            public string test { get; set; }
        }
        public class TripTypeViewModel : ITest
        {
            public string test { get; set; }
        }
        public interface ITest
        {
            string test { get; set; } 
        }
