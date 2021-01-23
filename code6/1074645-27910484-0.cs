    public class Term
    {
        public int Family { get; set; }
    }
    
    public class Document
    {
        private List<Term> terms = new List<Term>();
        public List<Term> Terms { get { return terms; } set { terms = value; } } 
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            Term t1 = new Term { Family = 1 };
            Term t2 = new Term { Family = 1 };
            Term t3 = new Term { Family = 1 };
            Document d1 = new Document();
            d1.Terms.Add(t1);
            d1.Terms.Add(t2);
            d1.Terms.Add(t3);
            Term t4 = new Term { Family = 1 };
            Term t5 = new Term { Family = 2 };
            Term t6 = new Term { Family = 3 };
            Document d2 = new Document();
            d2.Terms.Add(t4);
            d2.Terms.Add(t5);
            d2.Terms.Add(t6);
            List<Document> docs = new List<Document> {d1, d2};
        }
    }
