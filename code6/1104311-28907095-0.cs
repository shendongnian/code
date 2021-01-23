    public class TheTypeMoqMakes : Variables 
    {
      Enumerator Variables.GetEnumerator()
      {
        // Use expression tree you provided with 'Setup' without 'As'.
        // If you did not provide one, just return null.
      }
      Enumerator IEnumerable.GetEnumerator()
      {
        // Use expression tree you provided with 'Setup' with 'As<IEnumerable>'.
        // If you did not provide one, just return null.
      }
    }
