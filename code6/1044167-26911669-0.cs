        List<string> femalePetNames = { "Maggie", "Penny", "Saya", "Princess", 
                                "Abby", "Laila", "Sadie", "Olivia", 
                                "Starlight", "Talla" };
        public void StringRandom()
        {
            if (femalePetNames.Count > 0)
            {
                Random bsd = new Random();
                int fIndex = bsd.Next(0, femalePetNames.Count);
                txttBox2.Text = femalePetNames[fIndex];
                femalePetNames.RemoveAt(fIndex);
            }
        }
