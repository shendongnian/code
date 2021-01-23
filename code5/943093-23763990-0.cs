        public List<jquery> GetVersion(string path)
        {
            var thelist = (from afile in System.IO.Directory.EnumerateFiles(path)
                let version = removeLetters(afile)
                select removeLetters(afile).Split('.')
                into splitup
                select new jquery()
                {
                    Filename = filename,
                    //will want to add some additional checking here as if the length is not 3 then there will be other errors.
                    //just a starting point for you
                    Major = string.IsNullOrWhiteSpace(splitup[0]) ? 0 : int.Parse(splitup[0]), 
                    Minor = string.IsNullOrWhiteSpace(splitup[1]) ? 0 : int.Parse(splitup[1]), 
                    Build = string.IsNullOrWhiteSpace(splitup[2]) ? 0 : int.Parse(splitup[2]),
                }).ToList();
            return thelist
                .OrderByDescending(f => f.Major)
                .ThenByDescending(f => f.Minor)
                .ThenByDescending(f => f.Build)
                .ToList();
        }
        public string removeLetters(string value)
        {
            var chars = value.ToCharArray().Where(c => Char.IsNumber(c) || c.Equals('.'));
            return chars.ToString();
        }
        public class jquery
        {
            public string Filename { get; set; }
            public int Major { get; set; }
            public int Minor { get; set; }
            public int Build { get; set; }
        }
