        public static Map AddressMapper(IList<string> column)
        {
            var map = new Map();
            var splitBasedOnHTML = Regex.Split(column[2], @"\b<br>");
            var splitBasedOnSpace = splitBasedOnHTML[1].Split(' ');
            map.Street = splitBasedOnHTML[0];
            map.City = splitBasedOnSpace[0].Replace(@",", " ");
            map.State = splitBasedOnSpace[1];
            map.Zip = spliteBasedOnSpace[2];
            return map;
        }
