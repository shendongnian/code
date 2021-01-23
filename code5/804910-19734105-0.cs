    class Widget
    {
      public DateTime? DateCreated { get ; set ; }
    }
    
    class WidgetComparer : IComparer<Widget> , IComparer<DateTime?>
    {
      public bool NullCollatesHigh { get ; private set ; }
      private WidgetComparer( bool nullCollatesHigh )
      {
        this.NullCollatesHigh = nullCollatesHigh ;
        return ;
      }
      
      public int Compare( Widget x , Widget y )
      {
        int cc ;
        
        if      ( x == null && y == null ) cc = 0 ;
        else if ( x != null && y != null ) cc = Compare( x.DateCreated , y.DateCreated ) ;
        else if ( NullCollatesHigh       ) cc = x == null ? +1 : -1 ;
        else                               cc = x == null ? -1 : +1 ;
        
        return cc ;
      }
      public int  Compare(DateTime? x, DateTime? y)
      {
        int cc ;
        
        if      ( x == null && y == null ) cc = 0 ;
        else if ( x != null && y != null ) cc = DateTime.Compare( x.Value , y.Value ) ;
        else if ( NullCollatesHigh       ) cc = x == null ? +1 : -1 ;
        else                               cc = x == null ? -1 : +1 ;
        
        return cc ;
      }
      
    }
