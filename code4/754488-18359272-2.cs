    class Node
    {
        public int ID { get; set; }
        public Node[] Children { get; set; }
        public Node(int id, Node[] children)
        {
            ID = id;
            Children = children;
        }
        public Node(int id)
        {
            ID = id;
            Children = new Node[] { };
        }
    }
    class Program
    {
        public static HtmlGenericControl GetList(Node root)
        {
            HtmlGenericControl ul = new HtmlGenericControl("ul");
            GetListImpl(root, ul);
            return ul;
        }
        private static void GetListImpl(Node root, HtmlGenericControl rootElement)
        {
            foreach (var item in root.Children)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                li.InnerText = item.ID.ToString();
                if (item.Children.Length > 0)
                    li.Controls.Add(GetList(item));
                rootElement.Controls.Add(li);
            }
        }
        public static string HtmlGenericControlToString(HtmlGenericControl control)
        {
            string contents = null;
            using (System.IO.StringWriter swriter = new System.IO.StringWriter())
            {
                HtmlTextWriter writer = new HtmlTextWriter(swriter);
                control.RenderControl(writer);
                contents = swriter.ToString();
            }
            return contents;
        }
        static void Main(string[] args)
        {
            Node root = new Node(0,
                new Node[]{
                    new Node(1, new Node[]{
                        new Node(1),
                        new Node(2)
                    }),
                     new Node(2, new Node[]{
                        new Node(1),
                        new Node(2, new Node[]{
                            new Node(1)
                        })
                    })
                });
            var ul = GetList(root);
            var html = HtmlGenericControlToString(ul);
            Console.WriteLine(html);
        }
    }
