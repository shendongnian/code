    public UnifiedDTO GetAllCardTitle(IWhatParmType parameter, string procedureName)
    {
       switch( parameter )
       {
          case (eWhatAmI.ListedObjects):
             // Just for grins, test to make sure object really IS expected list version object
             if( parameter is MyListVersion)
                DoViaList( (MyListVersion)parameter );
             break;
    
          case (eWhatAmI.StringArrays ):
             if( parameter is MyArrayVersion )
                DoViaArray( (MyArrayVersion)parameter );
             break;
       }
    }
    
    private void DoViaList( MyListVersion parm1 )
    {
       .. do whatever based on the "List<string>" property
    }
    
    private void DoViaArray( MyArrayVersion parm1 )
    {
       .. do whatever based on the "string []" property
    }
