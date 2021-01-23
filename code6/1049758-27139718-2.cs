    using System;
    namespace DateTimeComparison
    {
       public class Program
       {
           static void Main( string[] args )
           {
               DateTimeOffset current = DateTimeOffset.Now;
               DateTimeOffset first = current;
               DateTimeOffset second = current;
               // 23 hours later, next day, with negative offset (EST) -- First rolls over
               first = new DateTimeOffset( 2014, 1, 1, 19, 0, 0, new TimeSpan( -5, 0, 0 ) );
               second = new DateTimeOffset( 2014, 1, 2, 18, 0, 0, new TimeSpan( -5, 0, 0 ) );
               if( false == SameDate( first, second ) ) {
                   Console.WriteLine( "Different day values!" );
               } else {
                   Console.WriteLine( "Same day value!" );
               }
               // --Comment is wrong -- 23 hours earlier, next day, with positive offset -- First rollovers
               first = new DateTimeOffset( 2014, 1, 1, 4, 0, 0, new TimeSpan( 5, 0, 0 ) );
               second = new DateTimeOffset( 2014, 1, 2, 5, 0, 0, new TimeSpan( 5, 0, 0 ) );
               if( false == SameDate( first, second ) ) {
                   Console.WriteLine( "Different day values!" );
               } else {
                   Console.WriteLine( "Same day value!" );
               }
               // 23 hours later, next day, with negative offset (EST) -- Second rolls over
               first = new DateTimeOffset( 2014, 1, 2, 18, 0, 0, new TimeSpan( -5, 0, 0 ) );
               second = new DateTimeOffset( 2014, 1, 1, 19, 0, 0, new TimeSpan( -5, 0, 0 ) );
               if( false == SameDate( first, second ) ) {
                   Console.WriteLine( "Different day values!" );
               } else {
                   Console.WriteLine( "Same day value!" );
               }
               // --Comment is wrong --  23 hours earlier, next day, with positive offset -- Second rolls over
               first = new DateTimeOffset( 2014, 1, 2, 5, 0, 0, new TimeSpan( 5, 0, 0 ) );
               second = new DateTimeOffset( 2014, 1, 1, 4, 0, 0, new TimeSpan( 5, 0, 0 ) );
               if( false == SameDate( first, second ) ) {
                   Console.WriteLine( "Different day values!" );
               } else {
                   Console.WriteLine( "Same day value!" );
               }
           }
           public static bool SameDate( DateTimeOffset first, DateTimeOffset second )
           {
               bool returnValue = false;
               DateTime firstAdjusted = first.UtcDateTime;
               DateTime secondAdjusted = second.UtcDateTime;
               if( firstAdjusted.Date == secondAdjusted.Date )
                   returnValue = true;
               return returnValue;
           }          
        }
    }
