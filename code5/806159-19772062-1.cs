    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main()
            {
                var _champs = new List<Champ>();
                var noPage = 0;
                var q = _champs.Any(a => a.NoPage == noPage + 1);
            }
        }
    }
