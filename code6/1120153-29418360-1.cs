    public class StatefulThings : IEnumerable<Thing>
    {
      bool _moveNextExecuted = false;
      public override bool MoveNext()
       {
          // Perform next pointer
          // Set state of hasBeenEnumerated in here...
          _moveNextExecuted  = true;
       }
    }
