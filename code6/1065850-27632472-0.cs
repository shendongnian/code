    class Program
    {
        static void Main(string[] args)
        {
            var dic = 
                codes
                .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split('='))
                .Select(x => new { Key = x[0].Trim(), Code = x[1].Trim() })
                .ToDictionary(x => x.Key, x => x.Code);
        }
    
        private static string codes =
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
