    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication7
    {
      class Program
      {
        static string GenerateHtml( int numberOfRooms )
        {
          var sb = new StringBuilder();
          for ( int a = 1 ; a < numberOfRooms ; a++ )
          {
            sb.AppendFormat( "<div id=HotelRoom{0}>"                            , a ).AppendLine() ;
            sb.AppendFormat( "  <p>Room {0}</p>"                                , a ).AppendLine() ;
            sb.AppendFormat( "  <select id=room{0}>"                            , a ).AppendLine() ;
            sb.AppendFormat( "    <option value=\"0\">Adults (18+)</option>"        ).AppendLine() ;
            for ( int i = 1 ; i < 9 ; i++ )
            {
            sb.AppendFormat( "    <option value={0}>{0}</option>"               , i ).AppendLine() ;
            }
            sb.AppendFormat( "  </select>"                                          ).AppendLine() ;
            sb.AppendFormat( "  <select id=ChildCountRoom{0}>"                  , a ).AppendLine() ;
            sb.AppendFormat( "    <option value=\"0\">Children 0 - 17</option>"     ).AppendLine() ;
            for ( int i = 1 ; i < 4 ; i++ )
            {
            sb.AppendFormat( "    <option value={0}>{0}</option>"               , i ).AppendLine() ;
            }
            sb.AppendFormat( "  </select>"                                          ).AppendLine() ;
            sb.AppendFormat( "</div>"                                               ).AppendLine() ;
            sb.AppendFormat( "<div id=\"NumberOfChildrenRoom{0}\"></div>"       , a ).AppendLine() ;
          }
          return sb.ToString();
        }
        static void Main()
        {
          for ( int i = 0 ; i < 5 ; ++i )
          {
            Console.WriteLine() ;
            Console.WriteLine("=== {0} =============================================================" , i ) ;
            string html = GenerateHtml(i) ;
            Console.WriteLine( html ) ;
            Console.WriteLine("=====================================================================") ;
          }
          return;
        }
      }
    }
