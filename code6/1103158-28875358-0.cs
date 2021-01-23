            DateTime dtStart;
            DateTime dtStop;
            
            if (dtStop.Hour > dtStart.Hour) 
            {
                Console.WriteLine("minutes for {0} h = {1}", dtStart.Hour, 60 - dtStart.Minute);
                Console.WriteLine("minutes for {0} h = {1}", dtStop.Hour, dtStop.Minute);
            }
            else
            {
                Console.WriteLine("minutes for {0} h = {1}", dtStop.Hour, dtStop.Minute - dtStart.Minute);
            }
