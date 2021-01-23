    public class Transaction 
    {
        //...
        public override string ToString() 
        {
            // Guess field names from constructor:
            //  new Transaction(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetString(3), reader.GetDouble(4))
        
            return String.Format("#{0}: {1} {2} {3} {4} {5}", id, timestamp, string1, string2, number);
        }
        // ...
    }
