    class Program
    {
        public static Node theNode;
        void Main()
        {
            ...
            while (!attempt)
            {
                int temp = theInput.TheUsersInput();
                theNode = new Node(temp);
                theTree.Add(temp);
                theNode.PrintNodes();
                attempt = theInput.AddMoreNumbers();
            }
            // you can start using theNode globally from this point
        }
    }
