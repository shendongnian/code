    public static void swap(ref Node n1, ref Node n2)
    {
        
            Node tempN1 = new Node(n1.value);
            tempN1.left = n1.left;
            tempN1.right = n1.right;
            tempN1.parent = n1.parent;
            Node tempN2 = new Node(n2.value);
            tempN2.left = n2.left;
            tempN2.right = n2.right;
            tempN2.parent = n2.parent;
            n1 = tempN2;
            n2 = tempN1;
    }
