      interface IHasSsn
      {
           string Ssn;
      }
    private void BuildDict<T>( List<T> list, 
                               ConcurrentDictionary<Int64, List<T>> theDict)
       where T : IHasSsn
    {
        foreach ( T cv in list )
        {
            long ssn = Convert.ToInt64( cv.Ssn );
            if ( theDict.ContainsKey(ssn) )
            {
                theDict[ssn].Add( cv );
            }
            else
            {
                var cvList = new List<T>();
                cvList.Add( cv );
                theDict.AddOrUpdate(ssn, cvList, ( foundkey, oldvalue  => cvList );
            }
        }
    }
