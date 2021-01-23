    List<Node> noder = new List<Node>();
    for (int i = 0; i < input.Length;i++)
    {   
        karakter = input[i];
    
        bool found = false;
        for (int j = 0; j < noder.Count;j++)
        {
            if (noder[j].ErTegn(karakter) == false)
            {
                noder[j].ØkMed1();
                found = true;
                break;
            }
        }
        if(!found)
        {
            noder.Add(new Node(karakter));
        }
    }
    foreach(Node n in noder)
    {
        txtOutput.Text += n.Resultat();
    }
