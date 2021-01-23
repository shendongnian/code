    public void AddMusicCDToFront(MusicCD cd)
    {
        Node newNode = new Node(cd);
        newNode.Link = head;
        head = newNode;
        count++;
    }
