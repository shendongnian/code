    List<List<int>> List = new List<List<int>>();
    List<int> SubList = new List<int>();
                    
                                
    List.Add(new List<int> { 1 });
    List.Add(new List<int> { 2, 3 });
    List.Add(new List<int> { 4, 5, 6 });
            
    this.textBox2.Text = List[0].Count.ToString();
