    private static IEnumerable<int> IndexesWhereThereIsOneInTheColumn(
        IEnumerable<List<int>> myIntsGrid)
    {
	    for (int i=0; myIntsGrid.Max(l=>l.Count) > i;i++)
		{
		    foreach(var row in myIntsGrid)
			{
			    if (row.Count > i && row[i] == 1)
				{
				    yield return i;
					break;
				}
			}
		}		
    }
 
