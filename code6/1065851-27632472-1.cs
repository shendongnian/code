    class Program
    {
        static void Main(string[] args)
        {
            var pairsEnum =
                 pairs
                .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split('='))
                .Select(x => new { Key = x[0].Trim(), Code = x[1].Trim() });
    
            var multipleKeys =
                pairsEnum
                .GroupBy(x => x.Key, (key, codes) => new { Key = key, Codes = codes })
                .Where(x => x.Codes.Count() > 1)
                .Select(x => new { Key = x.Key, Codes = x.Codes })
                .ToList();
    
            var multipleCodes =
              pairsEnum
               .GroupBy(x => x.Code, (code, keys) => new { Code = code, Keys = keys })
               .Where(x => x.Keys.Count() > 1)
               .Select(x => new { Keys = x.Keys, Code = x.Code})
               .ToList();
    
            var dic1 =
                pairsEnum
                .ToDictionary(x => x.Key, x => x.Code);
    
            // This will throw the same exception as in your example.
            var dic2 =
                pairsEnum
                .ToDictionary(x => x.Code, x => x.Key);
        }
    
        private static string pairs =
            @"
            a=.-
            b=-...
            c=-.-.
            d=-..
            e=.
            f=..-.
            g=--.
            h=....
            i=..
            j=.---
            k=-.-
            l=.-..
            m=--
            n=-.
            o=---
            p=.--.
            q=--.-
            r=.-.
            s=...
            t=-
            u=..-
            v=...-
            w=.--
            x=-..-
            y=-.--
            z=--..
            1=.----
            2=..---
            3=...--
            4=....-
            5=.....
            6=-....
            7=--...
            8=---..
            9=----.
            0=-----
            .=.-.-.-
            ,=--..--
            ?=..--..
            !=--..-
            ;=-.-.-.
            :=---...
            (=--...
            )=-.--.-
            """"=.-..-.
            -=-....-
            _=..--.-
            @=.--.-.
            +=.-.-.
            /=-..-.
            '=.----.
            á=.--.-
            ä=.-.-
            é=..-..
            ö=---.
            ü=..--
            ň=--.--";
    }
