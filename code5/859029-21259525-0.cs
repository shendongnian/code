    public class Part
    {
        public MemberType member;
        ...
        public Product parent;
        Part(Product p)
        {
             parent = p;
        }
    }
    public class Product
    {
        public Part part1;
        ...
    }
