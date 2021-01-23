    class Node {
        public string val;
        public List<Node> children = new List<Node>();
        public static Node Parse(string input) {
            Node n = new Node();
            //extract value and children
            Regex reg = new Regex("(?<val>\\w+)(?:\\((?<children>(?:\\([^()]*\\)|.)*)\\))?");
            // fill value
            Match match = reg.Match(input);
            n.val = match.Groups["val"].Value;
            
            // if children group matched
            if (match.Groups["children"].Success) { 
                // split through commas outside of parenthesis
                string[] childrenTab = Regex.Split(match.Groups["children"].Value, ",(?![^(]*\\))");
                // and call recursively for each child
                foreach (string child in childrenTab) {
                    n.children.Add(Node.Parse(child));
                }
            }
            return n;
        }
