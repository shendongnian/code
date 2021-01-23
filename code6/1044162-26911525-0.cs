    void Main()
    {
        textBox1.Text = NonRepeatingName();
        textBox2.Text = NonRepeatingName();
        textBox3.Text = NonRepeatingName();
        // ...
        textBoxN.Text = NonRepeatingName();
    }
    string[] femalePetNames = { "Maggie", "Penny", "Saya", "Princess", 
                                    "Abby", "Laila", "Sadie", "Olivia", 
                                    "Starlight", "Talla" };
    
    IEnumerator<string> randomNameEnumerator;
    public string NonRepeatingName()
    {
        if (randomNameEnumerator == null || !randomNameEnumerator.MoveNext())
        {
            randomNameEnumerator = femalePetNames.OrderBy( x=> Guid.NewGuid()).GetEnumerator();
    		randomNameEnumerator.MoveNext();
        }
        return randomNameEnumerator.Current;
    }
    
