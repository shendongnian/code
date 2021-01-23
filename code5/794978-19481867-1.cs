    public void ReadList()
    {
        FileStream stream = new FileStream(@"persons.dat", FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        myList = (List<Person>)formatter.Deserialize(stream);
        // Here I was creating a new list.. List<Person> myList = (List<Person>)formatter.Deserialize(stream);
        stream.Close();
    }
