    public abstract class CalendarBaseItem
    {
        abstract void Process(SomeData somedata);
    //...
    }
    
    public class RotaItem : CalendarBaseItem
    {
        public override void Process(SomeData somedata)
        {
            // now we know we're dealing with a `RotaItem` instance,
            // and the specialized ProcessItem can be called
            someData.ProcessItem(this);
        }
    //...
    }
    
    public class SomeData
    {
        public void ProcessItem(RotaItem item)
        {
            //...
        }
        public void ProcessItem(NoteItem item)
        {
            //...
        }
    }
