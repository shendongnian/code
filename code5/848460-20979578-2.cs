    public class KeyStore
    {
        public SortedDictionary<string, string> PrimaryKeys
        {
            get;
            set;
        }
        public KeyStore(string pkName, string pkValue)
        {
            PrimaryKeys = new SortedDictionary<string, string> { { pkName, pkValue } };
        }
        public KeyStore()
        {
            PrimaryKeys = new SortedDictionary<string, string>();
        }
        public override bool Equals(object obj)
        {
            if(obj == null || (KeyStore)obj == null)
                return false;
            KeyStore temp = (KeyStore)obj;
            return ToString() == temp.ToString();
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override string ToString()
        {
            return PrimaryKeys.Count.ToString() + " : \n" + string.Join("\n",(from kvp in PrimaryKeys
                                                                              let s = kvp.Key + " - " + kvp.Value
                                                                              select s));
        }
    }
    List<KeyStore> Lista = new List<KeyStore>
    {
        new KeyStore("testa","testa1"),
        new KeyStore("testb","testb1"),
        new KeyStore("testc", "testc1")
    };
    List<KeyStore> Listb = new List<KeyStore>
    {
        new KeyStore("testa","testa1"),
        new KeyStore("testd","testb1"),
        new KeyStore("testc", "testa1"),
        new KeyStore("teste", "teste1")
    };
    var Listc = Lista.Intersect(Listb).ToList();
    var Listd = Lista.Except(Listb).ToList();
    ?Listc
    Count = 1
        [0]: {1 : 
    testa - testa1}
    ?Listd
    Count = 2
        [0]: {1 : 
    testb - testb1}
        [1]: {1 : 
    testc - testc1}
