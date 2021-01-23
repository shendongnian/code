    public class BaseRecord : IRecord
    {
        public void DisplayName()
        {
            Console.WriteLine("BaseRecord");
        }
    }
    public class DerivedRecordOne : BaseRecord, IRecord
    {
        public void DisplayName()
        {
            Console.WriteLine("DerivedRecordOne");
        }
    }
    public class DerivedRecordTwo : BaseRecord, IRecord
    {
        public void DisplayName()
        {
            Console.WriteLine("DerivedRecordTwo");
        }
    }
