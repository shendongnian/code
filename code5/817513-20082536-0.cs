    private static void PoiataTiettyArvo(ref Solmu lista)
    {
        Console.WriteLine("Anna arvo jonka haluat poistaa: ");
        int PoistaMinut = int.Parse(Console.ReadLine());
        var previousNode = null;
        var currentNode = lista;
        while (currentNode != null)
        {
            int arvo = Convert.ToInt32(lista.data);
            if (PoistaMinut == arvo)
            {
                if (previousNode == null)
                {
                    // If there was no previous node, the head of the list is being deleted.
                    // update lista
                    lista = currentNode;
                }
                else
                {
                    previousNode.next = currentNode.next;
                    if (currentNode.next != null)
                    {
                        currentNode.next.prev = previousNode;
                    }
                }
                break;
            }
            previousNode = currentNode;
            currentNode = currentNode.next;
        }
    }
