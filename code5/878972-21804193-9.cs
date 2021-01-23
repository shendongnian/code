    var yourObj = JsonConvert.DeserializeObject<MyCustomType.Rootobject>(yourjson);
----
    public class MyCustomType
    {
        public class Rootobject
        {
            public Datum[] data { get; set; }
        }
        public class Datum
        {
            public string id { get; set; }
            public string al { get; set; }
            public string[] datapsi { get; set; }
            public string[] tags { get; set; }
            public string partype { get; set; }
            public Info info { get; set; }
            public Factors factors { get; set; }
            public Espace[] espace { get; set; }
            public Annex Annex { get; set; }
        }
        public class Info
        {
            public string nopub { get; set; }
            public int nodem { get; set; }
        }
        public class Factors
        {
            public int a { get; set; }
            public float b { get; set; }
            public int c { get; set; }
            public float d { get; set; }
            public int e { get; set; }
            public float f { get; set; }
            public float g { get; set; }
            public int h { get; set; }
            public int i { get; set; }
            public int j { get; set; }
            public int k { get; set; }
            public int l { get; set; }
            public float m { get; set; }
            public int n { get; set; }
            public int o { get; set; }
            public int p { get; set; }
            public float q { get; set; }
            public float r { get; set; }
            public int s { get; set; }
            public float t { get; set; }
        }
        public class Annex
        {
            public string name { get; set; }
            public Image image { get; set; }
        }
        public class Espace
        {
            public string id { get; set; }
            public string description { get; set; }
            public Datatip datatip { get; set; }
            public Image image { get; set; }
            public string resource { get; set; }
            public int delta { get; set; }
            public int[] target { get; set; }
            public string targetType { get; set; }
            public string targetOneLined { get; set; }
            public int[] alx { get; set; }
            public string alxOneLined { get; set; }
            public int[][] damps { get; set; }
            public string[] dampsOneLined { get; set; }
            public Var[] vars { get; set; }
            public object misc { get; set; }
            public string miscOneLined { get; set; }
        }
        public class Datatip
        {
            public string[] label { get; set; }
            public string[] damps { get; set; }
        }
        public class Image
        {
            public string full { get; set; }
            public string sprite { get; set; }
            public string group { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public int w { get; set; }
            public int h { get; set; }
        }
        public class Var
        {
            public string key { get; set; }
            public string link { get; set; }
            public float coeff { get; set; }
        }
    }
