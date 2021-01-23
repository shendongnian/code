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
    Random r = new Random();
    
    public string NonRepeatingName()
    {
        if (randomNameEnumerator == null || !randomNameEnumerator.MoveNext())
        {
            randomNameEnumerator = femalePetNames.OrderBy( x=> r.Next()).GetEnumerator();
    		randomNameEnumerator.MoveNext();
        }
        return randomNameEnumerator.Current;
    }
    
