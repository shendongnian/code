    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    
    namespace Xmlarrayload
    {
        class Program
        {
            static void Main(string[] args)
            {
                var document = XDocument.Parse(@"<TIMEWINDOWS>
        <NUMBER>4</NUMBER>
        <NO0>
            <FROM>22-11-2013 08:00:00</FROM>
            <TO>22-11-2013 11:59:00</TO>
        </NO0>
        <NO1>
            <FROM>22-11-2013 12:00:00</FROM>
            <TO>22-11-2013 15:59:00</TO>
        </NO1>
        <NO2>
            <FROM>23-11-2013 08:00:00</FROM>
            <TO>23-11-2013 11:59:00</TO>
        </NO2>
        <NO3>
            <FROM>23-11-2013 12:00:00</FROM>
            <TO>23-11-2013 15:59:00</TO>
        </NO3>
    </TIMEWINDOWS>");
    
                int number = int.Parse(document.Root.Element("NUMBER").Value);
                TimeWindow[] windows = (TimeWindow[])Array.CreateInstance(typeof(TimeWindow), number);
    
                for (int i = 0; i < number; i++)
                {
                    var element = document.Root.Element(string.Format("NO{0}", i));
                    TimeWindow window = new TimeWindow
                    {
                        //it is extremely important to use the correct culture (invariant) to parse the dates.
                        To = DateTime.ParseExact(element.Element("TO").Value, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat),
                        From = DateTime.ParseExact(element.Element("FROM").Value, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
                    };
                    windows[i] = window;
                }
            }
        }
    
        public class TimeWindow
        {
            public DateTime From { get; set; }
            public DateTime To { get; set; }
        }
    }
