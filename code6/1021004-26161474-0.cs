    public static List<T> CloneList<T>(List<T> oldList)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, oldList);
            stream.Position = 0;
            return (List<T>)formatter.Deserialize(stream);
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> firstList = new List<string>() { "1", "2", "3"}; //list with some items
            List<string> secondList = CloneList(firstList); //copyOfFirstList
            List<string> elementsToDelete = new List<string>() { "1" }; // do some logic to find all items you need to delete
            foreach (var item in elementsToDelete)
            {
                secondList.Remove(item);
            }
        }
