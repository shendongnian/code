    List<string> femalePetNames = { "Maggie", "Penny", "Saya", "Princess", 
                                    "Abby", "Laila", "Sadie", "Olivia", 
                                    "Starlight", "Talla" };
    Random bsd = new Random();
    
    public void StringRandom()
    {   
        if(femalePetNames.Length == 0)
        {
            // Do something here to handle when you've used all the pet names.
        }
        int fIndex = bsd.Next(0, femalePetNames.Length);
        txttBox2.Text = femalePetNames[fIndex];
        femalePetNames.RemoveAt(fIndex);
    }
