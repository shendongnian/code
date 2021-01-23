    Regex rxDate = new Regex( @"(?<day>\d+)-(?<month>\d+)-(?<year>\d+)\..*$" ) ;
    
    string[] unsorted = [ "page1.aspx_12-05-2013.aspx" ,
                          "page2.aspx_12-04-2010.aspx" ,
                          "page1.aspx_17-09-2014.aspx" ,
                          "page1.aspx_11-01-2013.aspx" ,
                        ] ;
    
    string[] sorted = unsorted
                      .Select( s => {
                          Match m   = rxDate.Match(s) ;
                          int day   = m.Success ? int.Parse(m.Groups[ "day"   ].Value : 0 ;
                          int month = m.Success ? int.Parse(m.Groups[ "month" ].Value : 0 ;
                          int year  = m.Success ? int.Parse(m.Groups[ "year"  ].Value : 0 ;
                          return new { Year=year , Month = month , Day = day , Name = s } ;
                        })
                      .OrderBy( x => x.Year )
                      .ThenBy( x => x.Month )
                      .ThenBy( x => x.Day   )
                      .Select( x => x.Name  )
                      .ToArray()
                      ;
