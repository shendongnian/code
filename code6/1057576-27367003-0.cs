    public class Player
    {
        public string name { get; set; }
        public int value { get; set; }
    }
    public void MyTest()
    {
        var myList = new List<Player>
        {
            new Player { name = "Player 1", value = 5 },
            new Player { name = "Player 1", value = 10 },
            new Player { name = "Player 1", value = 13 },
            new Player { name = "Player 2", value = 3 },
            new Player { name = "Player 2", value = 4 },
            new Player { name = "Player 2", value = 6 }
        };
        var mySummedList = myList.GroupBy(x => x.name).Select(x => new Player { name = x.Key, value = x.Sum(y => y.value)});
        foreach(var val in mySummedList)
        {
            Debug.WriteLine(String.Format("{0}: {1}", val.name, val.value));
        }
    }
    //Output:
    //Player 1: 28
    //Player 2: 13
