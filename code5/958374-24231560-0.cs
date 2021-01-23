    public static void recursiveInsert(int value, ref MyLinkedList list)
    {
        if (list == null)
        {
            list = new MyLinkedList(value, null);
        }
        else
        {
            recursiveInsert(value, ref list.next);
        }
    }
